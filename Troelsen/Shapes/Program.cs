using System;

namespace Shapes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Polymorphism *****");
            Shape[] shapes =
            {
                new Hexagon(), new Hexagon("Beth"), new Hexagon("Lina"),
                new Circle(), new Circle("Cindy")
            };
            foreach (var s in shapes) s.Draw();
            Console.ReadLine();
        }
    }

    //Абстрактный класс иерархии
    internal abstract class Shape
    {
        public Shape(string name = "NoName")
        {
            PetName = name;
        }

        public string PetName { get; set; }
        public abstract void Draw();
    }

    //Классы
    internal class Circle : Shape
    {
        public Circle()
        {
        }

        public Circle(string name) : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Circle", PetName);
        }
    }

    internal class Hexagon : Shape
    {
        public Hexagon()
        {
        }

        public Hexagon(string name) : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }
    }
}