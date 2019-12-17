using System;
using AttributedCarLibrary;

namespace VehicleDescriptionAttributeReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Value of VehicleDescnptionAttribute *****\n");
            ReflectonAttributesUsingEarlyBinding();
            Console.ReadLine();
        }

        private static void ReflectonAttributesUsingEarlyBinding()
        {
            // Получить объект Type, представляющий тип Winnebago.
            Type type = typeof(Winnebago);
            object[] customAtts = type.GetCustomAttributes(false);
            foreach(VehicleDescriptionAttribute vehicleDescription in customAtts)
            {
                Console.WriteLine("-> {0}\n", vehicleDescription.Description);
            }
        }
    }
}
