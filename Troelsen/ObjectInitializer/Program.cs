using System;

namespace ObjectInitializer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Object Init Syntax *****");
            //Устанвливаем свойства вручную
            var firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.DisplayStats();
            //Устанвливаем свойства специальным конструктором
            var secondPoint = new Point(20, 20);
            secondPoint.DisplayStats();
            //Устанвливаем свойства используя синтаксис инициализации
            var thirdPoint = new Point {Y = 30, X = 30};
            thirdPoint.DisplayStats();

            var goldPoint = new Point(PointColor.Gold) {Y = 90, X = 60};
            goldPoint.DisplayStats();

            Console.ReadLine();
        }
    }
}