﻿using System;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Employee Class Hierarchy *****\n");
            SalesPerson fred = new SalesPerson();
            fred.Name = "Fred";
            fred.Age = 45;
            fred.SalesNumber = 50;
            fred.DisplayStats();
            Console.ReadLine();
        }
    }
}
