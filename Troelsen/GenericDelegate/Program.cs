using System;

namespace GenericDelegate
{
    delegate T MyGenericDelegate<T>(T arg);
    class Program
    {
        static void Main(string[] args)
        {
            MyGenericDelegate<string> myTStr = StringTarget;
            MyGenericDelegate<int> myTInt = IntTarget;
            Console.WriteLine(myTStr("hi my friend!"));
            Console.WriteLine(myTInt(5));
            Console.ReadLine();
        }
        static string StringTarget(string arg)
        {
            return $"hgdjg {arg} "; 
            //Console.WriteLine("appercase arg: {0}", arg.ToUpper());
            //Console.ReadLine();
        }
        static int IntTarget(int arg)
        {
            //Console.WriteLine("++arg: {0}", ++arg);
            //Console.ReadLine();
            return (5+ arg);
        }
    }
}
