using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            Console.WriteLine("a = {0}, b = {1}", a,b);
            Swap<int>(ref a,ref b);
            Console.WriteLine("After swap \na = {0}, b = {1}", a, b);
            Console.ReadLine();
            Person person1 = new Person("Serg", "Next", 45);
            Person person2 = new Person("Vika", "Curt", 39);
            Console.WriteLine("Before swap \na = {0}, b = {1}", person1, person2);
            Swap(ref person1, ref person2);
            Console.WriteLine("After swap \na = {0}, b = {1}", person1, person2);
            Console.ReadLine();
        }
        // Этот метод будет менять местами два элемента
        // типа, указанного в параметре <Т>.
        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
            T tmp = a;
            a = b;
            b = tmp;
        }
       
    }
}
