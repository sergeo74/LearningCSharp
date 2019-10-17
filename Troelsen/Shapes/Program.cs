using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Polymorphism *****");
            Shape[] shapes = { new Hexagon(), new Hexagon("Beth"), new Hexagon("Lina"),
                            new Circle(),new Circle("Cindy")};
            foreach(Shape s in shapes)
            {
                s.Draw();
            }
            Console.ReadLine();
        }
    }
    //Абстрактный класс иерархии
    abstract class Shape
    {
        public string PetName { get; set; }
        public Shape(string name = "NoName")
        {
            PetName = name;
        }
        public abstract void Draw();
        
    }
    //Классы
    class Circle : Shape
    {
        public Circle(){}
        public Circle(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Circle", PetName);
        }
    }
    class Hexagon : Shape
    {
        public Hexagon() { }
        public Hexagon(string name):base (name){}
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }
    }
}
