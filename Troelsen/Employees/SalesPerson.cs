namespace Employees
{
    internal class SalesPerson : Employee
    {
        //Количества продаж
        public int SalesNumber { get; set; }

        //Бонус продавца зависит от количества продаж
        public sealed override void GiveBonus(float amount)
        {
            var salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber <= 100)
            {
                salesBonus = 10;
            }
            else
            {
                if (SalesNumber >= 101 && SalesNumber <= 200)
                    salesBonus = 15;
                else
                    salesBonus = 20;
            }

            base.GiveBonus(amount * salesBonus);
        }

        #region Constructors

        public SalesPerson()
        {
        }

        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn,
            int numberOfSales) : base(fullName, age, empID, currPay, ssn)
        {
            SalesNumber = numberOfSales;
        }

        #endregion
    }

    internal sealed class PTSalesPerson : SalesPerson
    {
        public PTSalesPerson()
        {
        }

        public PTSalesPerson(string fullName, int age, int empID, float currPay, string ssn,
            int numberOfSales) : base(fullName, age, empID, currPay, ssn, numberOfSales)
        {
        }
    }
}