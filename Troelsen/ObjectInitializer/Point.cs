using System;

namespace ObjectInitializer
{
    internal enum PointColor
    {
        LightBlue,
        BlueRed,
        Gold
    }

    internal class Point
    {
        public Point(int xVal, int yVal)
        {
            X = xVal;
            Y = yVal;
            Color = PointColor.Gold;
        }

        public Point(PointColor ptColor)
        {
            Color = ptColor;
        }

        public Point() : this(PointColor.BlueRed)
        {
        }

        public int X { get; set; }
        public int Y { get; set; }
        public PointColor Color { get; set; }

        public void DisplayStats()
        {
            Console.WriteLine("[{0},{1}, {2}]", X, Y, Color);
        }
    }
}