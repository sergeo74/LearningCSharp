using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleIndexer
{
    class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> listPeople = new Dictionary<string,Person>();
        //Приведение для вызывающего кода
        public Person this[string name]
        {
            get => listPeople[name];
            set => listPeople[name] = value;
        }
        
        public int Count => listPeople.Count;
        //Поддержка foreach
        IEnumerator IEnumerable.GetEnumerator() => listPeople.GetEnumerator();
    }
}
