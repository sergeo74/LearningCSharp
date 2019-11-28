using System;

namespace ObjectOverrides
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With System.Object *****");
            var person = new Person("Sergeo", "Next", 45);
            var person1 = new Person("Sergeo", "Next", 45);
            // person1.Age = 40;
            Console.WriteLine("person.ToString(): {0}", person);
            Console.WriteLine("person1.ToString(): {0}", person1);

            //Тестируем Equals
            Console.WriteLine("person = person1 ? :{0}", person.Equals(person1));
            //Проверяем хэш коды
            Console.WriteLine("Same hash codes ? :{0}", person.GetHashCode() == person1.GetHashCode());
            //Эквивалентность
            Console.WriteLine("Poiting to same object ? :{0}", ReferenceEquals(person, person1));
            Console.ReadLine();
        }
    }

    internal class Person
    {
        public Person()
        {
        }

        public Person(string fName, string lName, int age)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"[First Name: {FirstName}; Last Name: {LastName}; Age: {Age}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is Person && obj != null)
            {
                Person temp;
                temp = (Person) obj;
                if (temp.FirstName == FirstName && temp.LastName == LastName &&
                    temp.Age == Age)
                    return true;
                return false;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}