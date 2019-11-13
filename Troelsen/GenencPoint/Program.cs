using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenencPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            // Точка с координатами типа int.
            Point<int> p = new Point<int>(10, 10);
            // Точка с координатами типа double.
            Point<double> p2 = new Point<double>(5.4, 3.3);
            Console.WriteLine("Point 1:{0} Point 2:{1}", p.ToString(), p2.ToString());
            Console.ReadLine();
        }
        struct Point<T>
        {
            // Обобщенные свойства
            public T X { get; set; }
            public T Y { get; set; }
            // Обобщенный конструктор
            public Point(T xVal, T yVal)
            {
                X = xVal;
                Y = yVal;
            }
            public override string ToString()
            {
                return $"[{X}, {Y}]";
            }
            public void ResetPoint()
            {
                X = default(T);
                Y = default(T);
            }
        }
    }
}
