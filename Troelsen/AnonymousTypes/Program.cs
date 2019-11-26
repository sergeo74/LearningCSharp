using System;

namespace AnonymousTypes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine ("***** Fun with Anonymous Types *****\n");
            
            // Создать анонимный тип, представляющий автомобиль.
            var myCar = new {Color = "Red", Make = "Lada", Speed = 90};
            
            // Выполнить рефлексию того, что сгенерировал компилятор.
            ReflectOverAnonymousType(myCar);
            
            // Вывести на консоль цвет и производителя.
            Console.WriteLine("Му car is а {0} {1}. ", myCar.Color, myCar.Make);
            
            // Теперь вызвать вспомогательный метод для построения
            // анонимного типа с указанием аргументов.
            BuildAnonType("BMW", "Black", 90);
            Console.ReadLine();
        
        }

        static void BuildAnonType(string make, string color, int currSp)
        {
            // Построить анонимный тип с применением входных аргументов
            var car = new {Make = make, Color = color, Speed = currSp};
            
            // Обратите внимание, что теперь этот тип можно
            // использовать для получения данных свойств!
            Console.WriteLine("{0} {1} going {2} MPH", car.Color, car.Make, car.Speed);
            
            // Анонимные типы имеют специальные реализации каждого
            // виртуального метода System.Object. Например:
            Console.WriteLine("ToString () == {0}", car.ToString());
        }
        
        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}",
                obj.GetType().Name,
                obj.GetType().BaseType);
            Console.WriteLine ("obj .ToStringO == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
            Console.WriteLine();
        }
    }
}