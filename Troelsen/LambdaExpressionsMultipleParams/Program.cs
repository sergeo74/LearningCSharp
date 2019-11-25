using System;
using System.Collections.Generic;


namespace LambdaExpressionsMultipleParams
{
    class Program
    {
        static void Main(string[] args)
        {
            // Зарегистрировать делегат как лямбда-выражение.
            SimpleMath m = new SimpleMath();
            m.SetMathHandler((string msg, int result)=>
            { Console.WriteLine("Message: {0}, Result: {1}", msg, result); });
            m.Add(10, 5);
            Console.ReadLine();
        }
    }
}
