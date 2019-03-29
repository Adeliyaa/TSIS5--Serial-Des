using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;


namespace W5E5ListSerialization
{
    /*public class Student
    {
        public string Name { get; set; }
        public string Gpa { get; set; }
    }*/ 

    class Food
    {

    }

    class Point
    {
        public int x;
        public int y;

        public Point(int x , int y)
        {
            this.x = x;
            this.y = y;

        }
    }

    class Worn
    {
        public List<char> body = new List<char>();
        public char sign;

        public Worn()
        {
            body.Add("o"); //snake with one element
        }

        public void Clear() //to clear previous eleement of massive
        {
            for(int i=0; i<body.Count;++i)
            {
                Console.SetCursorPosition(body[i].x , body[i].y);
            }
        }

        public void Draw()
        {
            for (int i=0; i<body.Count; ++i)
            {
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write()

            }
        }

        public void Move(int dx,int dy)//to execute the signals about up, down presiing the key
            //delta dy or dx is a  change in position 
            //the combination +1.0 0.+1 0.0 -1.0 0.-1
        {
            Clear();
            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            /* XmlSerializer xs = new XmlSerializer(typeof(List<Student>));
             FileStream fs = new FileStream("student.txt", FileMode.Create, FileAccess.Write);

             List<Student> students = new List<Student>();
             Random random = new Random(DateTime.Now.Second);

             for (int i = 0; i < 10; ++i)
             {
                 students.Add(new Student { Name = Guid.NewGuid().ToString(), Gpa = random.Next(0, 4).ToString() });
             }

             xs.Serialize(fs,students);
             fs.Close();*/

            Console.SetWindowSize(40, 40); //
            // avoid the writing the pres key in a console 
            Console.SetBufferSize(); // without it it will begunok
            Console.CursorVisible = false;
            Worn w = new Worn();

            while(true) // while infinite game
            {
                Console.Clear();
                Console.SetCursorPosition(20, 20); //writing in center
                Console.Write('o');
                Console.WriteLine(w.body[0]);
                w.Draw(); //draw first o in center
                


            }

           





        }
    }
}
