using System;
using System.Collections.Generic;

namespace FunWithGenericCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //UseGenericList();
            //UseGenericStack();
           UseSortedSet();
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
        static void UseGenericStack()
        {
            Stack < Person > stackOfPeople = new Stack<Person>();
            stackOfPeople.Push(new Person
            { FirstName = "Serg", LastName = "Boyar", Age = 45 });
            stackOfPeople.Push(new Person
            { FirstName = "Serg", LastName = "Next", Age = 45 });
            stackOfPeople.Push(new Person
            { FirstName = "Vova", LastName = "Next", Age = 17 });
            while (true)
            {
                try
                {
                    Console.WriteLine("First person: {0}", stackOfPeople.Peek());
                    Console.WriteLine("Poped off: {0}", stackOfPeople.Pop());
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("\nError! {0}", ex.Message);
                    break;
                }
            }
        }
        static void UseSortedSet()
        {
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person { FirstName = "Serg", LastName = "Boyar", Age = 45 },
                new Person { FirstName = "Serg", LastName = "Next", Age = 46 },
                new Person { FirstName = "Vova", LastName = "Next", Age = 17 }
            };
            foreach(Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
            setOfPeople.Add(new Person("John", "Qux", 3));
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
            
        }

    }
}
