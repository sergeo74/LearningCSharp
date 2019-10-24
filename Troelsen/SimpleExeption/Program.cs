using System;

namespace SimpleExeption
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Car
    {
        public const int MaxSpeed = 100;
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";
        //Автомобиль не сломался?
        bool carIdDead;
        //Есть радиоприёмник
        Radio radio = new Radio();
        //Конструктры
        public Car(){}
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        //Метод делегирует запрос к Radio
        public void CranckTunes(bool state)
        {
            radio.TurnOn(state);
        }
        //Прибавим скорость, если не перегрелся
        public void Accelerate(int delta)
        {
            if (carIdDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    Console.WriteLine("{0} is overheated!", PetName);
                    CurrentSpeed = 0;
                    carIdDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed = {0} ", CurrentSpeed);
                }
            }
        }
    }
    class Radio
    {
        public void TurnOn(bool on)
        {
            Console.WriteLine(on ? "Jamming...":"Quiet time...");
        }
    }
}
