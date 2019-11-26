using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ to Objects *****\n");
            QueryOverStrings();
            Console.ReadLine();
            QueryOverStringsWithExtensionMethods();
            Console.ReadLine();
            QueryOverStringsLongHand();
            Console.ReadLine();

        }

        //Вспомогательный метод
        static void QueryOverStrings()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3",
            "Daxter","System Shock 2" };

            // Построить выражение запроса для нахождения
            // элементов массива, которые содержат пробелы.
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;
            // Вывести результаты,
            foreach (string s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }
        }

        static void QueryOverStringsWithExtensionMethods()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3",
            "Daxter","System Shock 2" };

            // Построить выражение запроса для поиска
            // в массиве элементов, содержащих пробелы.
            IEnumerable<string> subset =
                currentVideoGames.Where(g => g.Contains(" ")).
                                    OrderBy(g=>g).
                                    Select(g => g);
            
            // Вывести результаты,
            foreach (string s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }
        }

        static void QueryOverStringsLongHand()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3",
            "Daxter","System Shock 2" };
            string[] gamesWithSpaces = new string[5];
            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                {
                    gamesWithSpaces[i] = currentVideoGames[i];
                }
                
            }
            // Отсортировать набор.
            Array.Sort(gamesWithSpaces);

            // Вывести результаты.
            foreach (string s in gamesWithSpaces)
            {
                if (s != null)
                    Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();

        }
    }

    
}
