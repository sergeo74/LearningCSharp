using System;

namespace ExtensionMethods
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Extension Methods *****\n");
            int myInt = 123456;
            //MyExtensions.DisplayDefiningAssembly(myInt);
            Console.WriteLine(myInt.ReverseDigits().ToString());
            myInt.DisplayDefiningAssembly();
            Console.ReadKey();
            
            // To же и в DataSet!
            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();
            Console.ReadKey();
            
            //Ив SoundPlayer!
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.DisplayDefiningAssembly();
            Console.ReadKey();
        }
    }
}