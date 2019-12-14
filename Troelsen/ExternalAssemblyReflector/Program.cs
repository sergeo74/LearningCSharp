using System;
using System.Reflection;

namespace ExternalAssemblyReflector
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("***** External Assembly Viewer *****");
            string asmName = "";
            Assembly asm = null;
            do
            {
                Console.WriteLine("\nEnter an assembly to evaluate");
                Console.WriteLine("or enter Q to quit: ");
                asmName = Console.ReadLine();
                if (asmName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                try
                {
                    asm= Assembly.LoadFrom(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch 
                {
                    Console.WriteLine("Sorry, can't find assembly.");
                }
            } while (true);
        }

        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n***** Types in Assembly *****");
            Console.WriteLine("->{0}", asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine("Type: {0}", type);
            }
            Console.WriteLine();
        }
    }
}