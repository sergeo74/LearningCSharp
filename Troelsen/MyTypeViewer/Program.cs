using System;
using System.Linq;

namespace MyTypeViewer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to MyTypeViewer *****");
            var typeName = "";
            do
            {
                Console.WriteLine("\nEnter a type name to evaluate");
                Console.Write("or enter Q to quit: ");
                typeName = Console.ReadLine();

                if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                    break;

                TryToDisplayTypeInfo(typeName);
            } while (true);
        }

        private static void ListMethods(Type type)
        {
            Console.WriteLine("***** Methods *****");
            var methodNames = from name in type.GetMethods() select name;
            foreach (var methodName in methodNames)
            {
                Console.WriteLine("->{0}", methodName);
            }
            Console.WriteLine();
        }

        private static void Listlnterfaces(Type type)
        {
            Console.WriteLine("***** Interfaces *****");
            var namesOfInterfaces = from interfaceName
                    in type.GetInterfaces()
                select interfaceName.Name;

            foreach (var name in namesOfInterfaces) Console.WriteLine("->{0}", name);
        }

        private static void ListFields(Type type)
        {
            Console.WriteLine("***** Fields *****");
            var namesOfFields = from fieldName
                    in type.GetFields()
                select fieldName.Name;

            foreach (var name in namesOfFields) Console.WriteLine("->{0}", name);
        }

        private static void ListProps(Type type)
        {
            Console.WriteLine("***** Props *****");
            var namesOfProps = from propName
                    in type.GetProperties()
                select propName.Name;

            foreach (var name in namesOfProps) Console.WriteLine("->{0}", name);
        }

        // Просто ради полноты картины
        private static void ListVariousStats(Type type)
        {
            Console.WriteLine("***** Various Statistics *****");
            Console.WriteLine("Base class is: {0}", type.BaseType);
            Console.WriteLine("Is type abstract? {0}", type.IsAbstract);
            Console.WriteLine("Is type sealed? {0}", type.IsSealed);
            Console.WriteLine("Is type generic?  {0}", type.IsGenericTypeDefinition); // Обобщенный?
            Console.WriteLine("Is type a class type? {0}", type.IsClass);
            Console.WriteLine();
        }

        private static void TryToDisplayTypeInfo(string typeName)
        {
            try
            {
                var type = Type.GetType(typeName);
                Console.WriteLine("");
                ListVariousStats(type);
                ListFields(type);
                ListProps(type);
                ListMethods(type);
                Listlnterfaces(type);
            }
            catch
            {
                Console.WriteLine("Sorry, can’t find type: {0}", typeName);
            }
        }
    }
}