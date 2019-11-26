﻿using System;
using System.Collections.Generic;

namespace InterfaceExtensions
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine ("***** Extending Interface Compatible Types *****\n");
            
            // System.Array реализует IEnumerable!
            string[] data =
            {
                "Wow", "this", "is", "sort","of","annoing",
                "but", "in", "a", "weird", "way", "fun!"
            };
            data.PrintDataAndBeep();
            Console.WriteLine();
            
            // List<T> реализует IEnumerable!
            List<int> myInts  = new List<int>() {10,15,20};
            myInts.PrintDataAndBeep();
            Console.ReadLine();
        }
    }
}