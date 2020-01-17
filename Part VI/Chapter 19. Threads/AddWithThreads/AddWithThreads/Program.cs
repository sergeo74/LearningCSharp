using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AddWithThreads
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Add(): {0}",
                     Thread.CurrentThread.ManagedThreadId);
            AddParams ap = new AddParams(10, 20);
            Thread thread1 = new Thread(new ParameterizedThreadStart(Add));
            thread1.Start(ap);

            // Ожидать, пока не поступит уведомление!
            waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!");
            Console.ReadLine();
        }

        static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in Add(): {0}",
                    Thread.CurrentThread.ManagedThreadId);
                AddParams addParams = (AddParams)data;
                Console.WriteLine("{0} + {1} is {2}",
                    addParams.a, addParams.b, addParams.a+ addParams.b);
                waitHandle.Set();
            }
        }
    }

    class AddParams
        {
            public int a, b;
            public AddParams(int num1, int num2)
            {
                a = num1;
                b = num2;
            }
        }

}
