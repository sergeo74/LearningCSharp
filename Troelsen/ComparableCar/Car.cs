using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar
{
    class Car:IComparable
    {
        public static IComparer SortByPetName
        {
            get { return (IComparer)new PetNameComparer(); }
        }
        public int CarID { get; set; }
        public const int MaxSpeed = 100;
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";
        //Автомобиль не сломался?
        bool carIdDead;
        //Есть радиоприёмник
        Radio radio = new Radio();
        //Конструктры
        public Car() { }
        public Car(string name, int speed, int id)
        {
            CurrentSpeed = speed;
            PetName = name;
            CarID = id;
        }
        //Реализация интерфейса IComparable
        int IComparable.CompareTo(object obj)
        {
            Car temp = obj as Car;
            if (temp != null) return this.CarID.CompareTo(temp.CarID);
            //{
            //    if (this.CarID > temp.CarID)
            //    {
            //        return 1;
            //    }
            //    if (this.CarID < temp.CarID)
            //    {
            //        return -1;
            //    }
            //    else
            //    {
            //        return 0;
            //    }
            //}
            else
            {
                throw new ArgumentException("Parameter is not a Car");
            }
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
                if (CurrentSpeed >= MaxSpeed)
                {
                    //Console.WriteLine("{0} is overheated!", PetName);
                    CurrentSpeed = 0;
                    carIdDead = true;
                    //Используем throw
                    //Console.ReadLine();
                    throw new Exception($"{PetName} has overheated!");
                }
                else
                {
                    Console.WriteLine("CurrentSpeed = {0} ", CurrentSpeed);
                }
            }
        }

    }
}

