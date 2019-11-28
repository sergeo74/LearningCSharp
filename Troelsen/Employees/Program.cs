using System;

namespace Employees
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** The Employee Class Hierarchy *****\n");
            var fred = new SalesPerson();
            fred.Name = "Fred";
            fred.Age = 45;
            fred.SalesNumber = 50;
            fred.DisplayStats();
            Console.ReadLine();
        }
    }
}