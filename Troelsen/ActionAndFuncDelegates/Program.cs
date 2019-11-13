using System;


namespace ActionAndFuncDelegates
{
    class Program
    {
        // Это цель для делегата Actiono.
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Установить цвет текста консоли.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }
            // Восстановить цвет.
            Console.ForegroundColor = previous;
        }
        // Цель для делегата Funco.
        static int Add(int x, int y)
        { return x + y;}
            static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Action and Func *****");
            // Использовать делегат ActionO для указания на DisplayMessage.
            Action <string, ConsoleColor, int> myAct= DisplayMessage;
            Func<int, int, int> func = Add;
            myAct("Action Message", ConsoleColor.Yellow, 5);
            Console.WriteLine(func(15,20));
            Console.ReadLine();
        }
    }
}
