using System;
using System.Collections;

namespace IssuesWithNongenericCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            UsePersonCollection();
            Console.ReadLine();
        }
        static void ArrayListOfRandomObjects()
        {
            //ArrayList может хранить всё
            ArrayList allMyObjects = new ArrayList();
            allMyObjects.Add(true);
            allMyObjects.Add("Vasia");
            allMyObjects.Add(50);
            allMyObjects.Add(12.6);
        }
        static void UsePersonCollection()
        {
            Console.WriteLine("***** Custom Person Collection *****\n");
            PersonCollection myPeople = new PersonCollection();
            myPeople.AddPerson(new Person("Sergeo", "Next", 45));
            myPeople.AddPerson(new Person("Vika", "Next", 39));
            myPeople.AddPerson(new Person("Vova", "Tourtsev", 17));
            myPeople.AddPerson(new Person("Alan", "???", 18));

            foreach(Person person in myPeople)
            {
                Console.WriteLine(person);
            }
        }
    }
}
