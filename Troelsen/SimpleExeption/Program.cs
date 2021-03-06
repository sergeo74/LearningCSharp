﻿using System;

namespace SimpleExeption
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Exeption Example *****");
            Console.WriteLine("***** => Creating a car and stepping on it!");
            var myCar = new Car("GRANTA", 10);
            myCar.CranckTunes(true);
            try
            {
                for (var i = 0; i < 10; i++)
                    myCar.Accelerate(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n*** Error! ***");
                Console.WriteLine("Member name: {0}", e.TargetSite); //имя члена
                Console.WriteLine("Class defining member: {0}", e.TargetSite.DeclaringType); //class члена
                Console.WriteLine("Member type: {0}", e.TargetSite.MemberType); //имя члена
                Console.WriteLine("Message: {0}", e.Message); //сообщение
                Console.WriteLine("Source: {0}", e.Source); //источник
                Console.WriteLine("Stack: {0}", e.StackTrace);
            }

            Console.WriteLine("\n***** Out of exeption logic *****"); //источник
            Console.ReadLine();
        }
    }

    internal class Car
    {
        public const int MaxSpeed = 100;

        //Автомобиль не сломался?
        private bool carIdDead;

        //Есть радиоприёмник
        private readonly Radio radio = new Radio();

        //Конструктры
        public Car()
        {
        }

        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public int CurrentSpeed { get; set; }

        public string PetName { get; set; } = "";

        //Метод делегирует запрос к Radio
        public void CranckTunes(bool state)
        {
            radio.TurnOn(state);
        }

        //Прибавим скорость, если не перегрелся
        public void Accelerate(int delta)
        {
            if (carIdDead)
            {
                Console.WriteLine("{0} is out of order...", PetName);
            }
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed >= MaxSpeed)
                {
                    //Console.WriteLine("{0} is overheated!", PetName);
                    CurrentSpeed = 0;
                    carIdDead = true;
                    //Используем throw
                    //Console.ReadLine();
                    throw new Exception($"{PetName} has overheated!");
                }

                Console.WriteLine("CurrentSpeed = {0} ", CurrentSpeed);
            }
        }
    }

    internal class Radio
    {
        public void TurnOn(bool on)
        {
            Console.WriteLine(on ? "Jamming..." : "Quiet time...");
        }
    }
}