﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SyncDelegateReview
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Synch Delegate Review *****");

            // Вывести идентификатор выполняющегося потока.
            Console.WriteLine("Main() invoked on thread {0}.",
                Thread.CurrentThread.ManagedThreadId);

            // Вызвать Add() в синхронном режиме.
            BinaryOp b = new BinaryOp(Add);

            // Можно было бы также написать b.Invoke(10, 10);
            int answ = b(10, 10);

            // Эти строки кода не выполнятся до тех пор,
            // пока не завершится метод Add().
            Console.WriteLine("Doing more work in Main()!");
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
