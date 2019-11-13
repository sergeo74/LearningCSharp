using System;
using System.Collections.ObjectModel;

namespace FunWithObservableCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Сделать коллекцию наблюдаемой и добавить в неё несколько объектов
            ObservableCollection<Person> people = new ObservableCollection<Person>();
            people.Add(new Person("Sergeo", "Next", 45));
            people.Add(new Person("Vika", "Next", 39));
            //Привязаться к событию people_CollectionChanged
            people.CollectionChanged += people_CollectionChanged;
            people.Remove(people[1]);
            people.Add(new Person("Vova", "Next", 17));
            Console.ReadKey();
        }

        static void people_CollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Выяснить действие, которое привело к генерации события.
            Console.WriteLine("Action for this event: {0}", e.Action);
            //throw new NotImplementedException();
            // Было что-то удалено,
            if (e.Action ==
            System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:"); // старые элементы
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }

                Console.WriteLine();
            }
            // Было что-то добавлено.
            if (e.Action ==
            System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Теперь вывести новые элементы, которые были вставлены.
                Console.WriteLine("Here are the NEW items:"); // новые элементы
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }
    }
}
