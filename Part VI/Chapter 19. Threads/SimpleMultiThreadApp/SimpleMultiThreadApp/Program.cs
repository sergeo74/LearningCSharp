using System;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMultiThreadApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Amazing Thread App *****\n");
            Console.Write("Do you want [1] or [2] threads? ");
            string threadCount = Console.ReadLine();

            // Назначить имя текущему потоку.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            // Вывести информацию о потоке.
            Console.WriteLine("-> {0} is executing Main ()",
                Thread.CurrentThread.Name);

            Printer printer = new Printer();
            switch (threadCount)
            {
                case "2":
                    Thread backgroundThread = 
                        new Thread(new ThreadStart(printer.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;
                case "1":
                    printer.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("I don't know what you want...you get 1 thread.");
                    goto case "1";
            }
            MessageBox.Show("I'm busy!", "Work on main thread...");
            Console.ReadLine();
        }
    }

    public class Printer
    {
        public void PrintNumbers()
        {
            // Вывести информацию о потоке.
            Console.WriteLine("-> {0} is executing PrintNumbers()",
                Thread.CurrentThread.Name);

            // Вывести числа.
            Console.WriteLine("Your numbers: ");
            for (int i = 1; i < 10; i++)
            {
                Console.Write("{0}, ", i);
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}
