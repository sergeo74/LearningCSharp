using System;
using System.Reflection;
using System.Linq;

namespace MyTypeViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to MyTypeViewer *****");
            string typeName;
            do
            {
                Console.WriteLine("\nEnter a type name to evaluate");
                Console.Write("or enter Q to quit: ");
                typeName = Console.ReadLine();

                if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                    break;

                TryToDisplayTypeInfo(typeName);
            }
            while (true);
        }

        static void ListMethods(Type type)
        {
            Console.WriteLine("***** Methods *****");
            MethodInfo[] methodInfos = type.GetMethods();
            foreach (MethodInfo method in methodInfos)
            {
                string retVal = method.ReturnType.FullName;
                string paramInfo = "( ";
                foreach(ParameterInfo parametrs in method.GetParameters())
                {
                    paramInfo += string.Format("{0} {1}", parametrs.ParameterType, parametrs.Name);
                }
                paramInfo += " )";

                Console.WriteLine("-> {0} {1} {2}", retVal, method.Name, paramInfo);
            }
            Console.WriteLine();
        }
        static void Listlnterfaces(Type type)
        {
            Console.WriteLine("***** Interfaces *****");
            var namesOfInterfaces = from interfaceName
                                    in type.GetInterfaces()
                                    select interfaceName.Name;
            
            foreach(var name in namesOfInterfaces)
            {
                Console.WriteLine("->{0}", name);
            }
        }
        static void ListFields(Type type)
        {
            Console.WriteLine("***** Fields *****");
            var namesOfFields = from fieldName
                                    in type.GetFields()
                                    select fieldName.Name;

            foreach (var name in namesOfFields)
            {
                Console.WriteLine("->{0}", name);
            }
        }
        static void ListProps(Type type)
        {
            Console.WriteLine("***** Props *****");
            var namesOfProps = from propName
                                    in type.GetProperties()
                                select propName.Name;

            foreach (var name in namesOfProps)
            {
                Console.WriteLine("->{0}", name);
            }
        }

        // Просто ради полноты картины
        static void ListVariousStats(Type type)
        {
            Console.WriteLine("***** Various Statistics *****");
            Console.WriteLine("Base class is: {0}", type.BaseType);
            Console.WriteLine("Is type abstract? {0}", type.IsAbstract);
            Console.WriteLine("Is type sealed? {0}", type.IsSealed);
            Console.WriteLine("Is type generic?  {0}", type.IsGenericTypeDefinition);// Обобщенный?
            Console.WriteLine("Is type a class type? {0}", type.IsClass);
            Console.WriteLine();
        }

        static void TryToDisplayTypeInfo(string typeName)
        {
            try
            {
                Type type = Type.GetType(typeName);
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
