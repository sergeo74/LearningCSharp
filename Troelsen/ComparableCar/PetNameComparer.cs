using System;
using System.Collections;

namespace ComparableCar
{
    class PetNameComparer:IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Car car1 = x as Car;
            Car car2 = y as Car;
            if (car1 != null && car2 != null)
            {
                return String.Compare(car1.PetName, car2.PetName);
            }
            else
                throw new ArgumentException("Parameter is not a Car");
            
        }
    }
}
