using System;

namespace ClonablePoint
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Cloning *****");

            var p3 = new Point(100, 100, "Jane");
            var p4 = (Point) p3.Clone();

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