using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Indexers *****\n");
            PersonCollection myPeople = new PersonCollection();
            myPeople["Sergeo"] = new Person("Sergeo", "Next", 45);
            myPeople["Vika"] = new Person("Vika", "Next", 39);
            myPeople["Vova"] = new Person("Vova", "Tourtsev", 17);
            myPeople["Alan"] = new Person("Alan", "???", 18);
            //foreach (Person person in myPeople)
            //{
            Person person = myPeople["Vova"];
                //Console.WriteLine("Person number: {0}", i); // номер лица
                //Console.WriteLine("Name: {0} {1}",
                 //   person.FirstName, person.LastName); // имя и фамилия
                //Console.WriteLine("Age: {0}", person.Age); // возраст
                Console.WriteLine(person.ToString());
            //}
            Console.ReadLine();
        }
    }
}
