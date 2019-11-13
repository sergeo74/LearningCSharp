using System;


namespace CarDelegate
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");
            // Создать объект Car.
            Car car = new Car("Lada", 100, 10);

            // Сообщить объекту Car, какой метод вызывать,
            // когда он пожелает отправить сообщение.
                            
            car.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent1));
            car.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));

            // Увеличить скорость (это инициирует события).
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                car.Accelerate(20);
            }
            //Удаляет функцию из списка
            car.UnRegisterWithCarEngine(OnCarEngineEvent2);
            
            for (int i = 0; i < 6; i++)
            {
                car.Accelerate(20);
            }

            Console.ReadLine();
        }
        // Цель для входящих сообщении.
        public static void OnCarEngineEvent1(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine( "=> {0}", msg);
            Console.WriteLine("\n") ;
        }
        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg.ToUpper());
            Console.WriteLine("\n");
        }

    }
}

