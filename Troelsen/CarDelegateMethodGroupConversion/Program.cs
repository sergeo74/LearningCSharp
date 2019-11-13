using System;


namespace CarDelegateMethodGroupConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Method Group Conversion *****\n");
            Car car = new Car();
            car.RegisterWithCarEngine(CallMeHere);
            // Увеличить скорость (это инициирует события).
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                car.Accelerate(20);
            }
            //Уведомления больше не поступают
            car.UnRegisterWithCarEngine(CallMeHere);

            for (int i = 0; i < 6; i++)
            {
                car.Accelerate(20);
            }

            Console.ReadLine();
        }
        static void CallMeHere(string msg)
        {
            Console.WriteLine(" = > Message from Car: {0}", msg);
        }
    }
}
