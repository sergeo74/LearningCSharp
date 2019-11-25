//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace OverloadedOps
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int xPos,int yPos)
        {
            X = xPos;
            Y = yPos;
        }
        public override string ToString() => $"[X{this.X}, Y{this.Y}]";
        
        // Перегруженная операция +.
        public static Point operator + (Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static Point operator +(Point p1, int change) =>
            new Point(p1.X + change, p1.Y + change);
        public static Point operator +(int change, Point p1) =>
        new Point(p1.X + change, p1.Y + change);
        // Добавить 1 к значениям Х/Y входного объекта Point.
        public static Point operator ++(Point p1) => new Point(p1.X + 1, p1.Y + 1);
        // Вычесть 1 из значений X/Y входного объекта Point.
        public static Point operator --(Point p1) => new Point(p1.X - 1, p1.Y - 1);
    }
}
