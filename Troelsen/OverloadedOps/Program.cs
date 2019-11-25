using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace OverloadedOps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Overloaded Operators *****\n");
            // Создать две точки.
            Point ptOne = new Point(100, 100);
            Point ptTwo = new Point(40, 40);
            Console.WriteLine("ptOne = {0}", ptOne);
            Console.WriteLine("ptTwo = {0}", ptTwo);
            // Сложить две точки, чтобы получить большую?
            Console.WriteLine("ptOne + ptTwo: {0}", ptOne + ptTwo);
            // Вычесть одну точку из другой, чтобы получить меньшую?
            Console.WriteLine("ptOne - ptTwo: {0}\n ", ptOne - ptTwo);
            // Выводит [110, 110] .
            Point biggerPoint = ptOne + 10;
            Console.WriteLine("ptOne + 10 = {0}", biggerPoint);
            // Выводит [120, 120].
            Console.WriteLine("10 + biggerPoint = {0}", 10 + biggerPoint);
            Console.WriteLine();
            Console.ReadLine();
            // Применение унарных операций ++ и -- к объекту Point.
            Point ptFive = new Point(1, 1);
            Console.WriteLine("++ptFjve = {0}", ++ptFive) ; // [2, 2]
            Console.WriteLine("--ptFive = {0}", --ptFive); // [1, 1]
             // Применение тех же операций в виде постфиксного инкремента/декремента.
            Point ptSix = new Point(20, 20);
            Console.WriteLine("ptSix++ = {0}", ptSix++); // [20, 20]
            Console.WriteLine("ptSix-- = {0}", ptSix--); // [21, 21]
            Console.ReadLine();
        }
    }
}
