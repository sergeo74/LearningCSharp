using System;

namespace Employees
{
    class SalesPerson: Employee
    {
        //Количества продаж
        public int SalesNumber { get; set; }
        public SalesPerson() {}
        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn,
            int numberOfSales) : base(fullName, age, empID, currPay, ssn)
        {
            SalesNumber = numberOfSales;
        }
        
    }
    sealed class PTSalesPerson : SalesPerson
    {
        public PTSalesPerson() {}
        public PTSalesPerson(string fullName, int age, int empID, float currPay, string ssn,
            int numberOfSales):base(fullName, age, empID, currPay, ssn, numberOfSales)
        {}
    }
}