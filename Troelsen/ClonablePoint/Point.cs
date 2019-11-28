using System;

namespace ClonablePoint
{
    internal class Point : ICloneable
    {
        public PointDescription desc = new PointDescription();

        public Point()
        {
        }

        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public Point(int xPos, int yPos, string petName) : this(xPos, yPos)
        {
            desc.PetName = petName;
        }

        public int X { get; set; }

        public int Y { get; set; }

        //{return $"X = {X}, Y = {Y}";}
        public object Clone() // => this.MemberwiseClone();
        {
            var clPoint = (Point) MemberwiseClone();
            var newdesc = new PointDescription();
            newdesc.PetName = desc.PetName;
            clPoint.desc = newdesc;
            return clPoint;
        }

        public override string ToString()
        {
            return $"X = {X}; Y = {Y}; Name = {desc.PetName}; \nID = {desc.PointID}";
        }
    }
}