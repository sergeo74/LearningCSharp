using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDescriptionAttributeReaderLateBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Value of VehicleDescriptionAttribute *****\n");
            ReflectonAttributesUsingEarlyBinding();
            Console.ReadLine();
        }

        private static void ReflectonAttributesUsingEarlyBinding()
        {
            try
            {
                // Загрузить локальную копию сборки AttributedCarLibrary.
                Assembly asm = Assembly.Load("AttributedCarLibrary");
                // Получить информацию о типе VehicleDescriptionAttribute.
                Type vehicleDescription = 
                    asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");
                // Получить информацию о типе свойства Description.
                PropertyInfo propDescription = vehicleDescription.GetProperty("Description");
                // Получить все типы в сборке.
                Type[] types = asm.GetTypes();
                foreach(Type type in types)
                {
                    object[] objs = type.GetCustomAttributes(vehicleDescription,false);
                    foreach(object o in objs)
                    {
                        Console.WriteLine("-> {0}: {1}\n",
                            type.Name, propDescription.GetValue(o,null));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
