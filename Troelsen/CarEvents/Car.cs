using System;


namespace CarEvents
{
    
    class Car
    {
        // Этот делегат работает в сочетании с событиями Саг.
        //public delegate void CarEngineHandler(object sender, CarEventArgs e);
        // Car может отправлять следующие события:
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        //Свойства
        public int MaxSpeed { get; set; } = 100;
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }
        //Автомобиль не сломался?
        bool carIsDead;
        
        //Конструкторы
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            PetName = name;
            MaxSpeed = maxSp;
        }
       
        //1. Определить новый тип делегата, который будет использоваться 
        //   для отправки уведомлений вызывающему коду.

        //2. Объявить переменную-член этого типа делегата в классе Саг.
        //private CarEngineHandler listOfHandlers;

        //3. Создать в классе Саг вспомогательную функцию для вызывающего кода
        //public void RegisterWithCarEngine(CarEngineHandler methodtocall)
        //{
        //    listOfHandlers += methodtocall;
        //}
        //Удаляет функцию из списка
        //public void UnRegisterWithCarEngine(CarEngineHandler methodtocall)
        //{
        //    listOfHandlers -= methodtocall;
        //}
        //4. Реализовать метод Accelerate () для обращения к списку вызовов
        //   делегата в подходящих обстоятельствах.
      
        public void Accelerate(int delta)
        {
            // Если этот автомобиль сломан, то отправить сообщение об этом,
            if (carIsDead)
            {
                Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            { CurrentSpeed += delta;
                // Автомобиль почти сломан?
                if (10 == (MaxSpeed - CurrentSpeed))
                {
                    AboutToBlow?.Invoke(this, 
                        new CarEventArgs("Careful buddy! Gonna blow!"));
                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}

