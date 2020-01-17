using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LateBindingWithDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Dynamic! *****");
            AddWithReflection();
            Console.ReadLine();
        }

        private static void AddWithReflection()
        {
            Assembly asm = Assembly.Load("MathLibrary");

            try
            {
                // Получить метаданные для типа SimpleMath.
                Type math = asm.GetType("MathLibrary.SimpleMath");
                
                dynamic obj = Activator.CreateInstance(math);

                Console.WriteLine("Result is: {0}", obj.Add(10, 40));
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
