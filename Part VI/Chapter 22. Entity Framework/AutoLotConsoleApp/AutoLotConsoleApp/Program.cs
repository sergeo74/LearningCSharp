using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  AutoLotConsoleApp.EF;
using AutoLotConsoleApp.Models;
using static System.Console;

namespace AutoLotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with ADO.NET EF *****\n");
            //int carId = AddNewRecord();
            //WriteLine(carId);
            PrintAllInventory();
            ReadLine();
        }

        private static int AddNewRecord()
        {
            // Добавить запись в таблицу Inventory базы данных AutoLot.
            using (var context = new AutoLotEntities())
            {
                try
                {
                    // В целях тестирования жестко закодировать данные для новой записи.
                    var  car = new Car {Make = "Yugo", Color = "Brown", CarNickName = "Brownie"};
                    context.Cars.Add(car);
                    context.SaveChanges();
                    // В случае успешного сохранения EF заполняет поле идентификатора
                    // значением, сгенерированным базой данных.
                    return car.CarId;
                }
                catch (Exception e)
                {
                    WriteLine(e.InnerException?.Message);
                    return 0;
                }
            }
        }

        private static void PrintAllInventory()
        {
            using (var context = new AutoLotEntities())
            {
                foreach (var car in context.Cars.Where(c => c.Make == "BMW"))
                {
                    WriteLine(car);
                }
            }
        }

        private static void RemoveRecord(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                Car carToDelete = context.Cars.Find(carId);
                if (carToDelete != null)
                {
                    context.Cars.Remove(carToDelete);
                    // Этот код предназначен чисто для демонстрации того,
                    // что состояние сущности изменилось на Deleted.
                    if (context.Entry(carToDelete).State != EntityState.Deleted)
                    {
                        throw new Exception("Unable to delete the record");
                    }

                    context.SaveChanges();
                }
            }
        }

        private static void RemoveMultipleRecords(IEnumerable<Car> carsToRemove)
        {
            using (var context = new AutoLotEntities())
            {
                context.Cars.RemoveRange(carsToRemove);
                context.SaveChanges();
            }
        }

        private static void RemoveRecordUsingEntityState(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                Car carToDelete = new Car {CarId = carId};
                context.Entry(carToDelete).State = EntityState.Deleted;

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    WriteLine(ex);
                }
            }
        }

        private static void UpdateRecord(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                Car carToUpdate = context.Cars.Find(carId);
                if (carToUpdate != null)
                {
                    carToUpdate.Color = "Blue";
                    context.SaveChanges();
                }
            }
        }
    }
}
