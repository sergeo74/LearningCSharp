using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsyncDelegate
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Async Delegate Invocation *****");

            // Вывести идентификатор выполняющегося потока.
            Console.WriteLine("Main() invoked on thread {0}.",
                Thread.CurrentThread.ManagedThreadId);

            // Вызвать Add() во вторичном потоке.
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult asyncResult = b.BeginInvoke(10, 10, null, null);

            // Выполнить другую работу в первичном потоке...
            Console.WriteLine("Doing more work in Main()!");

            // По готовности получить результат выполнения метода Add().
            int answ = b.EndInvoke(asyncResult);
            Console.WriteLine("10 + 10 is {0}", answ);
            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            // Вывести идентификатор выполняющегося потока.
            Console.WriteLine("Add () invoked on thread {0}.",
                Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
