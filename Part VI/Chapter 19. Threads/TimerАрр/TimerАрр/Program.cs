using System;
using System.Threading;

namespace TimerАрр
{
    class Program
    {
        static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}", DateTime.Now.ToLongTimeString());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***** Working with Timer type *****\n");
            TimerCallback timerCallback = new TimerCallback(PrintTime);
            _ = new Timer(timerCallback, null, 0, 1000);
            Console.WriteLine("Hit key to terminate...");
            _ = Console.ReadLine();

        }
    }
}
