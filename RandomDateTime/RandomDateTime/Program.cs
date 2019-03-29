using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDateTime
{
    class Program
    {
        //through function to handling seeding 
        public int GetRandomValue(int min, int max)
        {
            return new Random(DateTime.Now.Millisecond).Next(min, max);
        }

        static void Main(string[] args)
        {
            int seed1 = (int)DateTime.Now.Second;
            int seed2 = (int)DateTime.Now.Ticks;

            Console.WriteLine(seed1);
            Console.WriteLine(seed2);

            
            Random random1 = new Random();
            Console.WriteLine(random1.Next(10,20));

            //Creates your Random object
            Random random2 = new Random(seed1);
            //Your random value 
            Console.WriteLine(random2.Next(10,20));

            //shorter
            int random = new Random(DateTime.Now.Millisecond).Next(27,227);


            //grab a random value betweem 27 and 227
            Console.WriteLine(GetRandomValue(27, 227));
            
        }
    }
}
