using System;

namespace Employees
{
    class Employee
    {
        //Поля данных
        protected string empName;
        protected int empID;
        protected float currPay;
        protected int empAge;
        protected string empSSN;

        //Свойства
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error!");
                }
                else
                {
                    empName = value;
                }
            }
        }
        public int Age 
        {
            get => empAge;
            set => empAge = value;            
        }
        public int ID
        {
            get => empID; 
            set => empID = value;
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
        public string SocialSecurityNumber { get => empSSN; }

        //Конструкторы
        public Employee() {}
        public Employee(string name, int age, int id, float pay)

        {
            Name = name;
            ID = id;
            Pay = pay;
            Age = age;
        }
        
        public Employee(string name,int age, int id, float pay,string ssn):
            this(name, age, id, pay)
        {
            
            empSSN = ssn;
        }

        //Методы
        public void GiveBonus( float amount)
        {
            Pay += amount;
        }
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", empName);
            Console.WriteLine("ID: {0}", empID);
            Console.WriteLine("Age: {0}", empAge);
            Console.WriteLine("Pay: {0}", currPay);
        }
    }
}
