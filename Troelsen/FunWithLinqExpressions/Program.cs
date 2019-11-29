using System;
using System.Linq;

namespace FunWithLinqExpressions
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("******* Fun with Query Expressions *****\n");
            
            // Этот массив будет основой для тестирования...
            ProductInfo[] itemsInStock = new[]
            {
                new ProductInfo
                {
                    Name = "Mac's Coffee",
                    Description = "Coffee with TEETH",
                    NumberInStock = 24
                },
                new ProductInfo
                {
                    Name = "Milk Maid Milk",
                    Description = "Milk cow's love",
                    NumberInStock = 100
                },
                new ProductInfo
                {
                    Name = "Pure Silk Tofu",
                    Description = "Bland as Possible",
                    NumberInStock = 120
                },
                new ProductInfo
                {
                    Name = "Crunchy Pops",
                    Description = "Cheezy, peppery goodness",
                    NumberInStock = 2
                },
                new ProductInfo
                {
                    Name = "RipOff Water",
                    Description = "From the tap to your wallet",
                    NumberInStock = 24
                },
                new ProductInfo
                {
                    Name = "Classic Valpo Pizza",
                    Description = "Everyone loves pizza!",
                    NumberInStock = 73
                },
            };
            
            // Здесь мы будем вызывать разнообразные методы!
            SelectEverything(itemsInStock);
            ListProductNames(itemsInStock);
            GetOverstock(itemsInStock);
            GetNamesAndDescriptions(itemsInStock);
            Console.ReadLine();
        }

        static void SelectEverything(ProductInfo[] products)
        {
            var allProducts = from product in products select product;
            foreach (var prod in allProducts)
            {
                Console.WriteLine(prod.ToString ()); 
            }
        }
        static void ListProductNames(ProductInfo[] products)
        {
            // Теперь получить только наименования товаров.
            Console.WriteLine("Only product names:");
            var names = from p in products select p.Name;
            foreach (var n in names)
            {
                Console.WriteLine("Name: {0}", n) ;
            }
        }

        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("The overstock items!");
            // Получить только товары co складским запасом более 25 единиц.
            var overstock = from p in products where p.NumberInStock > 25 select p;
            foreach (var c in overstock)
            {
                Console.WriteLine(c.ToString());
            }
        }
        static void GetNamesAndDescriptions(ProductInfo[] products)
        {
            Console.WriteLine("Names and Descriptions:");
            var nameDesc = from p in products select new { p.Name, p.Description };
            foreach (var item in nameDesc)
            {
                // Можно было бы также использовать свойства Name и Description напрямую.
                Console .WriteLine (item.ToString());
            }
        }
    }

    class ProductInfo
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int NumberInStock { get; set; } = 0;
        public override string ToString()
        {
            return $"Name = {Name}, Description = {Description}, " +
                   $"Number in Stock = {NumberInStock}";
        }
    }
}