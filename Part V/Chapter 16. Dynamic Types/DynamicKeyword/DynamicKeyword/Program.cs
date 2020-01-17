using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChangeDynamicDataType();
            InvokeMembersOnDynamicData();
            Console.ReadLine();
        }
        static void ImplicitlyTypedVariable()
        {
            var a = new List<int> { 90 };
            // a = "Hello!"; //Ошибка!

        }
        static void ChangeDynamicDataType()
        {
            dynamic t = "Hello!"; //=>object t = "Hello!";

            Console.WriteLine("t is of type: {0}", t.GetType());

            t = false;
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = new List<int>();
            Console.WriteLine("t is of type: {0}", t.GetType());

        }
        static void InvokeMembersOnDynamicData()
        {
            dynamic textData = "Hello!";

            try
            {
                Console.WriteLine(textData.ToUpper());
                Console.WriteLine(textData.toupper());
                Console.WriteLine(textData.Foo(10, "ее", DateTime.Now));
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
