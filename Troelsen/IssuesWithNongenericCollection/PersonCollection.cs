using System;
using System.Collections;

namespace IssuesWithNongenericCollection
{
    class PersonCollection : IEnumerable
    {
        private ArrayList arPeople = new ArrayList();
        //Приведение для вызывающего кода
        public Person GetPerson(int pos)
        {
            return (Person)arPeople[pos];
        }
        //Добавляются только Person
        public void AddPerson(Person p)
        {
            arPeople.Add(p);
        }
        public int Count => arPeople.Count;
        //Поддержка foreach
        IEnumerator IEnumerable.GetEnumerator() => arPeople.GetEnumerator();
    }
}
