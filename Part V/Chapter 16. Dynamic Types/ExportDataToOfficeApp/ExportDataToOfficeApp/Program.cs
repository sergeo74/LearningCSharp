using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportDataToOfficeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carsInStock = new List<Car>
            {
                new Car {Color="Green", Make="VW", PetName="Mary"},
                new Car {Color="Red", Make="Saab", PetName="Mel"},
                new Car {Color="Black", Make="Ford", PetName="Hank"},
                new Car {Color="Yellow", Make="BMW", PetName="Davie"}
            };
            ExportToExcel(carsInStock);
            Console.ReadLine();
        }

        static void ExportToExcel(List<Car> cars)
        {
            // Загрузить Excel и затем создать новую пустую рабочую книгу.
            Excel.Application excelApp = new Excel.Application();
            //excelApp.Visible = true;
            //Console.ReadLine();
            excelApp.Workbooks.Add();
            
            // В этом примере используется единственный рабочий лист.
            Excel._Worksheet workSheet = excelApp.ActiveSheet;
            
            // Установить заголовки столбцов в ячейках.
            workSheet.Cells[1, "A"] = "Make";
            workSheet.Cells[1, "B"] = "Color";
            workSheet.Cells[1, "C"] = "Pet Name";
            
            // Отобразить все данные из List<Car> на ячейки электронной таблицы.
            int row = 1;
            foreach(Car car in cars)
            {
                row ++;
                workSheet.Cells[row, "A"] = car.Make;
                workSheet.Cells[row, "B"] = car.Color;
                workSheet.Cells[row, "C"] = car.PetName;
            }
            // Придать симпатичный вид табличным данным.
            workSheet.Range["A1"].AutoFormat
                (Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
            
            // Сохранить файл, завершить работу Excel и отобразить сообщение пользователю.
            workSheet.SaveAs($@"{Environment.CurrentDirectory}\Inventory.xlsx");
            excelApp.Quit();
            Console.WriteLine(
                "The Inventory.xslx file has been saved to your app folder");
        }
    }

    public class Car
    {
        public string Make { get; set; }
        public string Color { get; set; }
        public string PetName { get; set; }
    }
}
