using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DefaultAppDomainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the default AppDomain *****\n");
            InitDAD();
           // DisplayDADStats();
            ListAHAssembliesInAppDomain();
            
            Console.ReadLine();
        }

        private static void DisplayDADStats()
        {
            AppDomain defaultAD = System.AppDomain.CurrentDomain;
            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);
            Console.WriteLine("ID of domain in this process: {0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain?: {0}", defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);
        }
        private static void ListAHAssembliesInAppDomain()
        {
            AppDomain defaultAD = System.AppDomain.CurrentDomain;
            //Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
            var loadedAssemblies = from a in defaultAD.GetAssemblies()
                                   orderby a.GetName().Name
                                   select a;
            Console.WriteLine("\n***** Here are the assemblies loaded in {0} *****\n",
                defaultAD.FriendlyName);
            foreach(var asm in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", asm.GetName().Name);
                Console.WriteLine("-> Version: {0}", asm.GetName().Version);
            }
        }

        private static void InitDAD()
        {
            // Эта логика будет выводить имя любой сборки, загруженной
            //в домен приложения после его создания.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (o, s) => 
            {
                Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);
            };
        }

    }
}
