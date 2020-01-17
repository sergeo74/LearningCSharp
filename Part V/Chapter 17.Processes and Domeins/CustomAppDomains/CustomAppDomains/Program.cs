using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace CustomAppDomains
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with CustomAppDomains *****\n");
            // Вывести все сборки, загруженные в стандартный домен приложения
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.ProcessExit += (o, s) =>
             {
                 Console.WriteLine("Default AD unloaded!");
             };
            ListAHAssembliesInAppDomain(defaultAD);

            // Создать новый домен приложения.
            MakeNewAppDomain();
            Console.ReadLine();
        }

        private static void MakeNewAppDomain()
        {
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
            newAD.DomainUnload += (o, s) =>
            {
                Console.WriteLine("The second AppDomain has been unloaded!");
            };
            try
            {
                // Загрузить CarLibrary.dll в этот новый домен.
                newAD.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }

            ListAHAssembliesInAppDomain(newAD);

            // Избавиться от этого домена приложения.
            AppDomain.Unload(newAD);
        }

        private static void ListAHAssembliesInAppDomain(AppDomain ad)
        {
            var loadedAssemblies = from a in ad.GetAssemblies()
                                   orderby a.GetName().Name
                                   select a;
            Console.WriteLine("\n***** Here are the assemblies loaded in {0} *****\n",
                ad.FriendlyName);
            foreach (var asm in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", asm.GetName().Name);
                Console.WriteLine("-> Version: {0}", asm.GetName().Version);
            }
        }
    }
}
