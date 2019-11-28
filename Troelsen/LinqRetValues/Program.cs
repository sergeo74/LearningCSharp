using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LinqRetValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ Return Values *****\n");
            IEnumerable<string> subset = GetStringSubset();

            foreach (string s in subset)
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }

        static IEnumerable<string> GetStringSubset()
        {
            string[] colors =
            {
                "White", "Blue", "Yellow", "Red","Light Red","Dark Red"

            };
            IEnumerable<string> theRedColor = from c in colors
                where c.Contains("Red") select c;
            return theRedColor;
        }
    }
}
