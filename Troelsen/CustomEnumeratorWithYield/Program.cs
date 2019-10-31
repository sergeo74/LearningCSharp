using System;
using System.Collections;


namespace CustomEnumeratorWithYield
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage carLot = new Garage();
            IEnumerator i = carLot.GetEnumerator();
            i.MoveNext();
            Car car = (Car)i.Current;
            
            //foreach (Car c in carLot)
            //{
            Console.WriteLine("{0} is going {1} MPH", car.PetName, car.CurrentSpeed);
            //}
            Console.ReadKey();
        }
    }
}
