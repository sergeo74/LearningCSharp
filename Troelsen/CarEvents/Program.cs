using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Anonymous Methods *****\n");
            Car c1 = new Car("Lada", 100, 10);
            // Зарегистрировать обработчики событий как анонимные методы.
            //c1.AboutToBlow += delegate 
            //{
            //    Console.WriteLine("Eek! Going too fast!");
            //};
            c1.AboutToBlow += (object sender, CarEventArgs e) =>
            {
                    if (sender is Car)
                    {
                        Car car = (Car)sender;
                        Console.WriteLine("{0} says: {1}", car.PetName, e.msg);
                    }
            };
            //c1.Exploded += CarExploded;
            c1.Exploded += (sender, e) => Console.WriteLine(e.msg);
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            // Удалить метод CarExploded из списка вызовов,
            //c1.Exploded -= (sender, e) => Console.WriteLine(e.msg); 
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            Console.ReadLine();
        }

        //private static void CarAboutToBlow(object sender, CarEventArgs e)
        //{
        //    if (sender is Car)
        //    {
        //        Car car = (Car)sender;
        //        Console.WriteLine("{0} says: {1}", car.PetName, e.msg);
        //    }
            
        //}
        //private static void CarlsAlmostDoomed(object sender, CarEventArgs e)
        //{
        //    Console.WriteLine("=> Critical Message from Car: {0}", e.msg);
        //}
        //private static void CarExploded(object sender, CarEventArgs e)
        //{
        //    Console.WriteLine(e.msg);
        //}
    }
    public class CarEventArgs: EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message) 
        {
            msg = message;
        }
    }
}
