using System;

namespace Employees
{
    internal class Manager : Employee
    {
        public Manager()
        {
        }

        public Manager(string fullName, int age, int empID, float currPay, string ssn,
            int numberOfOpts) : base(fullName, age, empID, currPay, ssn)
        {
            StockOption = numberOfOpts;
        }

        //Количества фондовых опционов
        public int StockOption { get; set; }

        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            var random = new Random();
            StockOption += random.Next(500) * StockOption;
        }
    }
}