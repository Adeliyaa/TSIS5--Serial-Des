using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;



namespace SerialOverview
{
    [Serializable()] //Serialize the class
    public class Animal : ISerializable //Serializable interface
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int AnimalID { get; set; }

        public Animal() { }

        public Animal(string name = "No name",
            double weight = 0,
            double height = 0)
        {
            Name = name;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
            //alternative method of Print
        {
            return string.Format("{0} weighs {1} lbs and is {2} inches tall",
                Name, Weight, Height);
        }

        public void GetObjectData(SerializationInfo info, 
            StreamingContext context)
            //Serialization function which is going to store object data in a file 
            //SeriaInf hold key value pairs in your object 
            //Stream Cont holds addidtional information
        {
            info.AddValue("Name", Name);
            info.AddValue("Weight", Weight);
            info.AddValue("Height", Height);
        }

        //deserialization
        public Animal(SerializationInfo info,
            StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Weight = (double)info.GetValue("Weight", typeof(double));
            Height = (double)info.GetValue("Height", typeof(double));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal bowser = new Animal("Bowser", 45, 25);

            Stream stream = File.Open("Animal.txt", FileMode.Create);
            
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, bowser);

            stream.Close();

            bowser = null;

            stream = File.Open("Animal.txt", FileMode.Open);

            bf = new BinaryFormatter();

            bowser = (Animal)bf.Deserialize(stream);

            stream.Close();

            Console.WriteLine(bowser.ToString());

            bowser.Weight = 50;

            XmlSerializer xs = new XmlSerializer(typeof(Animal));

            using (TextWriter tw = new StreamWriter(@"C:\doo\Ser.txt"))
            {
                xs.Serialize(tw, bowser);
            }

            bowser = null; //because we have that information saved
            //we do not need to close the stream, because it is the reason why we use the USING

            XmlSerializer ds = new XmlSerializer(typeof(Animal));
            TextReader tr = new StreamReader(@"C:\doo\Ser.txt");
            object obj = ds.Deserialize(tr);
            bowser = (Animal)obj;
            tr.Close();

            Console.WriteLine(bowser.ToString());

            List<Animal> theAnimals = new List<Animal>
            {
                new Animal("Mario", 60, 30),
                new Animal("Luiga", 55, 24),
                new Animal("Peach", 40, 20)
            };

            using (Stream fs = new FileStream(@"C:\doo\asd.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer sr2 = new XmlSerializer(typeof(List<Animal>));
                sr2.Serialize(fs, theAnimals);
            }

            theAnimals = null;

            XmlSerializer sr3 = new XmlSerializer(typeof(List<Animal>));

            using (FileStream fs2 = File.OpenRead(@"C:\doo\asd.txt"))
            {
                theAnimals = (List < Animal >) sr3.Deserialize(fs2);
            }

            foreach(Animal a in theAnimals)
            {
                Console.WriteLine(a.ToString());
            }

            
        }
    }
}
