using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace W5E2XMLSerializer
{
    public class Student
    {
        public string name;
        public string gpa;

        public Student() { }

        /*public void PrintInfo()
        {
            Console.WriteLine(name + " " + gpa);
        }*/

        public override string ToString()
        {
            return name + " " + gpa;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            F1(); //function for serializing
            F2(); //function for deserilizing 
        }

        private static void F1()
        {
            Student s = new Student();
            s.gpa = Console.ReadLine();
            s.name = Console.ReadLine();

            /*
            s.gpa = "4.0";
            s.name = "AAAA";
             */

            //Console.WriteLine(s); //---> in order to get override ToString 

            //s.PrintInfo(); //--> call the function PrintInfo

            XmlSerializer xs = new XmlSerializer(typeof(Student));
            FileStream fs = new FileStream("student.xml", FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, s);
            fs.Close();
        }
    
        private static void F2()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            FileStream fs = new FileStream("student.xml", FileMode.Open, FileAccess.Read);
            Student student = xs.Deserialize(fs) as Student;
            Console.Write(student);
            fs.Close();
        }
    }
}
