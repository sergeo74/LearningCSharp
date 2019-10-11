using System;


namespace BasicInheritans
{
    class Car
    {
        public readonly int maxSpeed;
        private int currSpeed;
        public int Speed
        {
            get
            {
                return currSpeed;
            }

            set
            {
                currSpeed = value;
                if (currSpeed > maxSpeed)
                {
                    currSpeed = maxSpeed;
                }
            }
        }
        public Car()
        {
            maxSpeed = 55;
        }

        public Car(int max)
        {
            maxSpeed = max;
        }
    }
    sealed class MiniVan : Car
    {

    }
}
