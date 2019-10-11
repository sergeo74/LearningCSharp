﻿using System;

namespace Employees
{
    class Employee
    {
        //Поля данных
        private string empName;
        private int empID;
        private float currPay;

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
       
        //Конструкторы
        public Employee() {}
        public Employee(string name, int id, float pay)
        {
            Name = name;
            ID = id;
            Pay = pay;
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
            Console.WriteLine("Pay: {0}", currPay);
        }
    }
}
