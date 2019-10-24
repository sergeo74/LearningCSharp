using System;

namespace ObjectOverrides
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With System.Object *****");
            Person person = new Person("Sergeo","Next",45);
            Person person1 = new Person("Sergeo", "Next", 45);
           // person1.Age = 40;
            Console.WriteLine("person.ToString(): {0}", person.ToString());
            Console.WriteLine("person1.ToString(): {0}", person1.ToString());

            //Тестируем Equals
            Console.WriteLine("person = person1 ? :{0}", person.Equals(person1));
            //Проверяем хэш коды
            Console.WriteLine("Same hash codes ? :{0}", person.GetHashCode()== person1.GetHashCode());
            //Эквивалентность
            Console.WriteLine("Poiting to same object ? :{0}", object.ReferenceEquals(person,person1));
            Console.ReadLine();
        }
    }
    class Person 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person() {}
        public Person(string fName, string lName, int age)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
        }
        public override string ToString()
        {
            return $"[First Name: {FirstName}; Last Name: {LastName}; Age: {Age}]";
        }
        public override bool Equals(object obj)
        {
            if (obj is Person && obj != null)
            {
                Person temp;
                temp = (Person)obj;
                if (temp.FirstName == this.FirstName && temp.LastName == this.LastName &&
                    temp.Age == this.Age)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }
}
