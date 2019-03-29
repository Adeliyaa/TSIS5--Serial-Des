using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace W5E4ComplexNum
{
    [Serializable]
    public class Complex
    {
        public double a;
        public double b;

        XmlSerializer xs = new XmlSerializer(typeof(Complex));
        string fname = "complex.txt";

        public void PrintInfo()
        {
            Console.WriteLine(string.Format("{0} + {1} * i", a , b));
        }

        public override string ToString()
        {
            return string.Format("{0} + {1}i", a, b);
        }

        public void Serializing()
        {
            FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Close();
        }

        public Complex Deserilizing()
        {
            FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
            Complex complex = xs.Deserialize(fs) as Complex;
            fs.Close();
            return complex;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Complex c = new Complex();
            c.a = 2;
            c.b = 3;
            c.PrintInfo();
            c.Serializing();

            Complex c2 = c.Deserilizing();
            Console.WriteLine(c2);
        }
    }
}
