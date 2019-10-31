using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClonablePoint
{
    class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescription desc = new PointDescription();
        public Point() { }
        public Point(int xPos, int yPos)
        {
            X = xPos; Y = yPos;
        }
        public Point(int xPos, int yPos, string petName) : this ( xPos, yPos)
        {
           desc.PetName = petName;
        }
        public override string ToString() 
            => $"X = {X}; Y = {Y}; Name = {desc.PetName}; \nID = {desc.PointID}";
        //{return $"X = {X}, Y = {Y}";}
        public object  Clone()// => this.MemberwiseClone();
        {
            Point clPoint = (Point)this.MemberwiseClone();
            PointDescription newdesc = new PointDescription();
            newdesc.PetName = this.desc.PetName;
            clPoint.desc = newdesc;
            return clPoint;
        }
    }
}
