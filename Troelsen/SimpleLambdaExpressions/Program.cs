using System;
using System.Collections.Generic;

namespace SimpleLambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with Lambdas * ****\n");
            //TraditionalDelegateSyntax();
            //AnonymousMethodSyntax();
            LambdaExpressionSyntax();
            Console.ReadLine();
        }
        static void TraditionalDelegateSyntax()
        {
            // Создать список целочисленных значении.
            List<int> list = new List<int> { 20, 1, 4, 8, 9, 44 };
            // Вызвать FindAll () с применением традиционного синтаксиса делегатов
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);
            Console.WriteLine("Here is even numbers");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
        static void AnonymousMethodSyntax()
        {
            // Создать список целочисленных значении.
            List<int> list = new List<int> { 20, 1, 4, 8, 9, 44 };
            // Теперь использовать анонимный метод.
            List<int> evenNumbers = list.FindAll(delegate (int i)
            {return (i % 2) == 0;});
            Console.WriteLine("Here is even numbers");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
        static void LambdaExpressionSyntax()
        {
            // Создать список целочисленных значении.
            List<int> list = new List<int> { 20, 1, 4, 8, 9, 44 };
            // Теперь использовать анонимный метод.
            List<int> evenNumbers = list.FindAll( i =>
            {
                Console.WriteLine("value of i is currently: {0}", i);
                bool isEven = ((i % 2) == 0);
                return isEven;
            });
            Console.WriteLine("Here is even numbers");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
        // Цель для делегата PredicateO.
        static bool IsEvenNumber(int i)
        {
            // Это четное число?
            return (i % 2) == 0;
        }
    }
}
