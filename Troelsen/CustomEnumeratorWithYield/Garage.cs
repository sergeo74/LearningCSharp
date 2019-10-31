using System;
using System.Collections;

namespace CustomEnumeratorWithYield
{
    class Garage:IEnumerable
    {
        private Car[] carArray = new Car[4];
        public Garage()
        {
            carArray[0] = new Car("LADA",30);
            carArray[1] = new Car("Volga", 55);
            carArray[2] = new Car("Ford", 30);
            carArray[3] = new Car("Mazda", 30);
        }

        public IEnumerator GetEnumerator()
        {
            //throw new Exception("This won't get called");
            return actualImplementation();
            IEnumerator actualImplementation()
            {

                foreach (Car c in carArray)
                {
                    yield return c;
                }
            }
        }
        //public IEnumerator GetTheCars(bool returnReserved)
        //{
        //    //throw new Exception("This won't get called");
        //    return actualImplementation();
        //    IEnumerator actualImplementation()
        //    {

        //        foreach (Car c in carArray)
        //        {
        //            yield return c;
        //        }
        //    }
        //}
    }
}
