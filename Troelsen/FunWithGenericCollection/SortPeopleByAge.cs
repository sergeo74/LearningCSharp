using System.Collections.Generic;


namespace FunWithGenericCollection
{
    struct SortPeopleByAge:IComparer<Person>
    {
       
        public int Compare(Person person1, Person person2)
        { 
            if(person1?.Age > person2?.Age)
            {
                return 1;
            }
            if (person1?.Age < person2?.Age)
            {
                return -1;
            }
            return 0;
        }
              
    }
}
