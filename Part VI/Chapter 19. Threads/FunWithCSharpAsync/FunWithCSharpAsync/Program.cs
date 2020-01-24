using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithCSharpAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Async ===>");

            _ = DoWorkAsync();
           
            Console.WriteLine("Completed");
            Console.ReadLine();
            
        }
        static async Task DoWorkAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Done with work!");
            }
            );
        }

    }
}
