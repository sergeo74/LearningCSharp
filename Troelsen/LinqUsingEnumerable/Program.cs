using System;
using System.Linq;
using System.Security.Policy;

namespace LinqUsingEnumerable
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            QueryStringWithOperators();
            QueryStringsWithEnumerableAndLambdas();
            QueryStringsWithAnonymousMethods();
            VeryComplexQueryExpression.QueryStringsWithRawDelegates();
        }
        static void QueryStringWithOperators()
        {
            Console.WriteLine("***** Using Query Operators *****");
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", 
                "Daxter", "System Shock 2"};
            var subset = from game in currentVideoGames where game.Contains(" ")
                orderby game select game;
            foreach (string g in subset)
            {
                Console.WriteLine("Item: {0}",g );
            }

            Console.WriteLine();
        }
        static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", 
                "Daxter", "System Shock 2"};
            var subset = currentVideoGames.Where(game => game.Contains(" "))
                .OrderBy(game => game).Select(game => game);
            foreach (var g in subset)
            {
                Console.WriteLine("Item: {0}",g );
            }

            Console.WriteLine();
        }

        static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("***** Using Anonymous Methods *****");
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", 
                "Daxter", "System Shock 2"};
            // Построить необходимые делегаты Funco с использованием анонимных методов.
            Func<string, bool> searchFilter = delegate(string game) 
                { return game.Contains(" ");};
            Func<string, string> itemToProcess = delegate(string s) { return s;};
            // Передать делегаты в методы класса Enumerable.
            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess)
                .Select(itemToProcess);
            foreach (var g in subset)
            {
                Console.WriteLine("Item: {0}",g );
            }

        }
    }
    class VeryComplexQueryExpression
    {
        public static void QueryStringsWithRawDelegates()
        {
            Console.WriteLine("***** Using Raw Delegates *****");
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", 
                "Daxter", "System Shock 2"};
            // Построить необходимые делегаты Func<>.
            Func<string, bool> searchFilter = new Func<string, bool>(Filter) ;
            Func<string, string> itemToProcess = new Func<string, string> (Processltem);
            var subset =currentVideoGames.Where(searchFilter).OrderBy(itemToProcess)
                    .Select(itemToProcess);
            
            foreach (var g in subset)
            {
                Console.WriteLine("Item: {0}",g );
            }
        }
        // Цели делегатов.
        static bool Filter(string game) => game.Contains(" ");
        static string Processltem(string game) => game;
    }
    
}