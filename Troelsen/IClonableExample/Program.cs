using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IClonableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** A First Look at Interfaces *****");
            //Все эти классы поддерживают интерфейс IClonable
            string myStr = "Hello";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
            //Все классы могут быть переданы методу, принимающему параметр типа IClonable
            ClonMe(myStr);
            ClonMe(unixOS);
            ClonMe(sqlConn);
            Console.ReadLine();
        }
        private static void ClonMe(ICloneable c)
        {
            //Клонировать то, что получено и вывести его имя
            object theClone = c.Clone();
            Console.WriteLine("You clone is a: {0}", theClone.GetType().Name);
        }
    }
}
