using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinFormatter
{
    //Serialization is the process of converting an object into a form that can be readily transported.
    [Serializable] // the objects of class accepted to be serialized 
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name , int age)
        {
            Name = name;
            Age = age;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Object for serialization 
            Person person = new Person("Tom", 29);
            Console.WriteLine("Object is created...");

            //create the object Binary Formatter 
            BinaryFormatter formatter = new BinaryFormatter();

            //get the stream, where we will write serialized object 
            using (FileStream fs = new FileStream("people.txt", FileMode.OpenOrCreate))
                //write object person in a file people.txt
                //with "using" it is not necessary to close the stream 
            {
                formatter.Serialize(fs, person);

                Console.WriteLine(" Object is serialized... ");
            }

            //deserialize from file people.txt
            using (FileStream fs = new FileStream("people.txt", FileMode.OpenOrCreate))
            {
                Person newperson = (Person)formatter.Deserialize(fs);

                Console.WriteLine("Object is deserialize...");
                Console.WriteLine("Name: {0} ---- Age: {1}", newperson.Name, newperson.Age);

            }

            Console.ReadLine();

        }
    }
}
