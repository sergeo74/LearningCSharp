using System;


namespace ObjectInitializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Object Init Syntax *****");
            //Устанвливаем свойства вручную
            Point firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.DisplayStats();
            //Устанвливаем свойства специальным конструктором
            Point secondPoint = new Point(20, 20);
            secondPoint.DisplayStats();
            //Устанвливаем свойства используя синтаксис инициализации
            Point thirdPoint = new Point { Y = 30, X = 30 };
            thirdPoint.DisplayStats();

            Point goldPoint = new Point (PointColor.Gold) { Y = 90, X = 60 };
            goldPoint.DisplayStats();

            Console.ReadLine();

        }
    }
}
