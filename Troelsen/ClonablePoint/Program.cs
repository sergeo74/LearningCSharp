using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClonablePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Cloning *****");
           
            Point p3 = new Point(100, 100,"Jane");
            Point p4 = (Point)p3.Clone();

            Console.WriteLine("Before modification");
            Console.WriteLine("p3:{0}", p3);
            Console.WriteLine("p4:{0}", p4);
            p4.desc.PetName = "New point";
            p4.X = 0;
            Console.WriteLine("\nAfter modification");
            Console.WriteLine("p3:{0}", p3);
            Console.WriteLine("p4:{0}", p4);
            Console.ReadLine();
        }
    }
}
