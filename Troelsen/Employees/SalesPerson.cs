using System;

namespace Employees
{
    class SalesPerson: Employee
    {
        //Количества продаж
        public int SalesNumber { get; set; }
        #region Constructors
        public SalesPerson() {}
        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn,
            int numberOfSales) : base(fullName, age, empID, currPay, ssn)
        {
            SalesNumber = numberOfSales;
        }
        #endregion
        
        //Бонус продавца зависит от количества продаж
        public override sealed void GiveBonus(float amount)
        {
            int salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber <= 100)
                salesBonus = 10;
            else
            {
                if (SalesNumber >= 101 && SalesNumber <= 200)
                    salesBonus = 15;
                else
                    salesBonus = 20;
            }
            base.GiveBonus(amount*salesBonus);
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