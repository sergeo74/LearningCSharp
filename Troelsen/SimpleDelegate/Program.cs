using System;


namespace SimpleDelegate
{
    delegate int BinaryOp(int x, int y);
    class SimpleMath
    {
        
        public int Add(int a, int b) => (a + b);
        public int Dec(int a, int b) => (a - b);
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryOp b = new BinaryOp((new SimpleMath()).Add);
            DisplayDelegatelnfo(b);
            Console.WriteLine("10 + 10 = {0}", b(10, 10));
            Console.ReadLine();
        }
        static void DisplayDelegatelnfo(Delegate delObj)
        {
            // Вывести имена всех членов в списке вызовов делегата,
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("\nMethod Name: {0}", d.Method); // имя метода
                Console.WriteLine("Type Name: {0}", d.Target); // имя типа
            }
        }
    }   
}
