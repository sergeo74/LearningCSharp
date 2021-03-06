﻿using AutoLotDAL.Bulklmport;
using AutoLotDAL.DataOperations;
using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
namespace AutoLotClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //InventoryDAL dal = new InventoryDAL();
            //var list = dal.GetAllInventory();
            //Console.WriteLine("************** Аll Cars ************");
            //Console.WriteLine("CarId\tMake\tColor\tPet Name");
            //foreach (var itm in list)
            //{
            //    Console.WriteLine($"{itm.CarId}\t{itm.Make}\t{itm.Color}\t{itm.PetName}");
            //}
            //Console.WriteLine();
            //var car = dal.GetCar(list.OrderBy(x => x.Color).Select(x => x.CarId).First());
            //Console.WriteLine(" **************First Car By Color * *************");
            //Console.WriteLine("CarId\tMake\tColor\tPet Name");
            //Console.WriteLine($"{ car.CarId}\t{ car.Make}\t{ car.Color}\t{ car.PetName}");

            //    dal.DeleteCar(8);
            //    Console.WriteLine("Car deleted.");

            //var carForAdd = new Car { Color = "White", Make = "VAZ", PetName = "Granta" };
            //dal.InsertAuto(carForAdd);
            //Console.WriteLine("Car {0} added!", carForAdd.PetName);

            //list = dal.GetAllInventory();
            //var newCar = list.Last(x => x.PetName == "Granta");
            //Console.WriteLine("************** New Car **************");
            //Console.WriteLine("CarId\tMake\tColor\tPet Name");
            //Console.WriteLine($"{newCar.CarId}\t{newCar.Make}\t{newCar.Color}\t{newCar.PetName}");

            //var petName = dal.LookUpPetName(car.CarId);
            //Console.WriteLine($"Car pet name: {petName}");
            //Console.WriteLine("Press enter to continue...");

            //Console.ReadLine();
            //MoveCustomer();
            DoBulkCopy();
            Console.ReadLine();


        }

        public static void MoveCustomer()
        {
            Console.WriteLine("*****Simple Transaction Example *****\n");

            bool trowEx = true;

            Console.WriteLine("Do you want to throw an exception? (Y or N) : ");
            var userAnswer = Console.ReadLine();
            if (userAnswer?.ToLower() == "n")
            {
                trowEx = false;
            }

            var dal = new InventoryDAL();

            // Обработать клиента 1 - ввести идентификатор клиента,
            // подлежащего перемещению.
            dal.ProcessCreditRisk(trowEx, 2);
            Console.WriteLine("Check CreditRisk table for results");
            Console.ReadLine();
        }

        public static void DoBulkCopy()
        {
            Console.WriteLine("************** Do Bulk Copy **************");
            var cars = new List<Car>
            {
                new Car() { Color = "Blue", Make = "Honda", PetName = "MyCar1" },
                new Car() { Color = "Red", Make = "Volvo", PetName = "MyCar2" },
                new Car() { Color = "White", Make = "VW", PetName = "МуСагЗ" },
                new Car() { Color = "Yellow", Make = "Toyota", PetName = "MyCar4" }
            };

            ProcessBulkImport.ExecuteBulkImport(cars, "Inventory");

            InventoryDAL dAL = new InventoryDAL();
            var list = dAL.GetAllInventory();
            Console.WriteLine(" ************** All Cars ************** ");
            Console.WriteLine("CarId\tMake\tColor\tPet Name");
            foreach (var itm in list)
            {
                Console.WriteLine($"{itm.CarId}\t{itm.Make}\t{itm.Color}\t{itm.PetName}");
            }
            Console.WriteLine();
        }
    }
}