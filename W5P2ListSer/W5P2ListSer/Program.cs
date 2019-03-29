
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;


namespace W5P2ListSer
{
    public class Mark
    {
        public int points { get; set; }

        public string Getletter()
        {
            string res = "";
            switch (points)
            {
                case int n when (n <= 100 && n >= 95):
                    res = "A";
                    break;

                case int n when (n <= 94 && n >= 90):
                    Console.WriteLine("A-");
                    break;

                case int n when (n <= 89 && n >= 85):
                    Console.WriteLine("B+");
                    break;


                case int n when (n <= 84 && n >= 80):
                    Console.WriteLine("B");
                    break;


                case int n when (n <= 79 && n >= 75):
                    Console.WriteLine("B-");
                    break;


                case int n when (n <= 74 && n >= 70):
                    Console.WriteLine("C+");
                    break;


                case int n when (n <= 69 && n >= 65):
                    Console.WriteLine("C");
                    break;

                case int n when (n <= 64 && n >= 60):
                    Console.WriteLine("C-");
                    break;


                case int n when (n <= 59 && n >= 55):
                    Console.WriteLine("D+");
                    break;


                case int n when (n <= 54 && n >= 50):
                    Console.WriteLine("D");
                    break;


                case int n when (n <= 49 && n >= 0):
                    Console.WriteLine("F");
                    break;

                default:
                    Console.WriteLine("Invalid value");
                    break;
            }

            return res;

        }
        public override string ToString()
        {
            return string.Format("{0} points and the letter mark is {1} ",
                points, Getletter());
        }

    }

    

    class Program
    {
        static void Main(string[] args)
        {
            Mark a = new Mark();
            a.points = 95;

            Console.WriteLine(a.ToString());
            return;


            List<Mark> Marks = new List<Mark>();

            Marks.Add(a);
            //a.ToString();

            using (FileStream fs = new FileStream("asd.txt", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
                xs.Serialize(fs, Marks);
            }

            using (FileStream fs = new FileStream("asd.txt", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
                Marks = (List<Mark>)xs.Deserialize(fs);
            }

            foreach (Mark b in Marks)
            {
                Console.WriteLine(a.ToString());
            }

        }
    }
}
