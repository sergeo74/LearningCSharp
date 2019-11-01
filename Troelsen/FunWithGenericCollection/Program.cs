using System;
using System.Collections.Generic;

namespace FunWithGenericCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            UseGenericList();
            Console.ReadLine();
        }
        static void UseGenericList()
        {
            //Создать список Персон и заполнить
            List<Person> people = new List<Person>() 
            {
                new Person ("Serg","Boyar",45),
                new Person ("Serg","Next",45),
                new Person ("Vika","Next",39),
                new Person ("Vova","Next",17)
            };
            //Количество элементов
            Console.WriteLine("Людей в списке: {0}\n", people.Count);
            //Вывести список
            foreach (Person p in people) Console.WriteLine(p);
            Console.WriteLine("Людей в списке после добавления");
            //Добавить новый объект
            people.Add(new Person 
            { FirstName = "Gosha", LastName = "Ivanov", Age = 17 });
            //Вставить новый объект
            people.Insert(2,new Person
            { FirstName = "Sasha", LastName = "Gutsal", Age = 17 });
            foreach (Person p in people) Console.WriteLine(p);
            //Копируем в массив
            Console.WriteLine("Имена из массива:");
            Person[] arrPerson = people.ToArray();
            foreach(Person p in arrPerson) Console.WriteLine(p.FirstName);
            
        }
    }
}
