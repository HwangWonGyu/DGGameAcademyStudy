using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGreal_20170303
{
    class Program
    {
        static void Main(string[] args)
        {
            bool b = true;

            // WriteLine automatically converts the value of b to text.
            Console.WriteLine(b);

            int days = DateTime.Now.DayOfYear;

            Console.WriteLine(days);

            // Assign the result of a boolean expression to b.
            b = (days % 2 == 0);

            // Branch depending on whether b is true or false.
            if (b)
            {
                Console.WriteLine("days is an even number");
            }
            else
            {
                Console.WriteLine("days is an odd number");
            }
        }
    }
}
