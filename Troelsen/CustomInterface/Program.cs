using System;

namespace CustomInterface
{
    abstract class Shape
    {
        public string PetName { get; set; }
        public Shape(string name = "NoName")
        {
            PetName = name;
        }
        public abstract void Draw();

    }
    class Circle : Shape
    {
        public Circle() { }
        public Circle(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Circle", PetName);
        }
    }
    class ThreeDCircle : Circle, IDraw3D

    {
        public ThreeDCircle() { }
        public ThreeDCircle(string name) : base(name) { }

        public new string PetName { get; set; }
        public void Draw3D()
        {
            Console.WriteLine("Drawing Circle in 3D!");
        }
    }
    class Hexagon : Shape, IPointy, IDraw3D
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }
        public void Draw3D()
        {
            Console.WriteLine("Drawing Hexagon in 3D!");
        }
        public byte Points
        {
            get => 6;
        }
    }
    class Triangle : Shape, IPointy
    {
        public Triangle() { }
        public Triangle(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Triangle", PetName);
        }
        public byte Points
        {
            get => 3;
        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Interfaces *****");
            Shape[] shapes = { new Hexagon(), new Triangle("Joe"), new Circle("JoJo"), new ThreeDCircle("Vasia")};
            for (int i = 0; i< shapes.Length; i++)
            {
                shapes[i].Draw();
                if (shapes[i] is IPointy ip)
                {
                    Console.WriteLine("-> Points: {0}", ip.Points);
                }
                else
                {
                    Console.WriteLine("-> {0}\'s not pointy!", shapes[i].PetName);
                }
                if (shapes[i] is IDraw3D) DrawIn3D((IDraw3D)shapes[i]);
            }
            Console.ReadLine();
        }
        static void DrawIn3D(IDraw3D draw3D)
        {
            Console.WriteLine("Drawing IDraw3D compatible type");
            draw3D.Draw3D();
        }
    }
  
}
