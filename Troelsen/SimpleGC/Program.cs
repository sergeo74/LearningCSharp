using System;

namespace SimpleGC
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console .WriteLine ("***** GC Basics *****") ;
            
            // Создать новый объект Car в управляемой куче.
            // Возвращается ссылка на этот объект (refToMyCar).
            Car refToMyCar = new Car("Zippy", 50);
            
            // Операция точки (.) используется для обращения к членам
            // объекта с применением ссылочной переменной.
            Console.WriteLine(refToMyCar.ToString());
            //Console.ReadLine();
        }

        static void MakeACar()
        {
            // Если myCar - единственная ссылка на объект Саг, то после
            // завершения этого метода объект Саг *может* быть уничтожен.
            Car myCar = new Car();
            myCar = null;
        }
    }
}