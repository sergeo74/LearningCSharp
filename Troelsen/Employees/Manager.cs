using System;

namespace Employees
{
    class Manager:Employee
    {
        //Количества фондовых опционов
        public int StockOption { get; set; }
        public Manager() {}
        public Manager(string fullName, int age, int empID, float currPay, string ssn,
            int numberOfOpts): base (fullName, age, empID,currPay, ssn)
        {
            StockOption = numberOfOpts;
        }
        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random random = new Random();
            StockOption += random.Next(500) * StockOption;
        }

    }
}