using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyEBookReader
{
    class Program
    {
        //private static string theEBook = "";
        static void Main(string[] args)
        {
            GetBook();
            Console.ReadLine();
        }

        static void GetBook()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += (s, eArgs) =>
            {
                string theEBook = eArgs.Result;
                Console.WriteLine("Download complete.");
                GetStats(theEBook);
            };
            webClient.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
        }

        private static void GetStats(string theEBook)
        {
            string[] words = theEBook.Split(new char[]
            { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' }, StringSplitOptions.RemoveEmptyEntries);

            // Найти 10 наиболее часто встречающихся слов.
            string[] tenMostCommon = null;//FindTenMostCommon(words);

            // Получить самое длинное слово.
            string longestWord = string.Empty;//FindLongestWord(words);

            Parallel.Invoke(
                () =>
                {tenMostCommon = FindTenMostCommon(words);},
                () =>
                {longestWord = FindLongestWord(words);}
                );

            // Когда все задачи завершены, построить строку,
            // показывающую всю статистику в окне сообщений
            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            foreach (string s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }
            bookStats.AppendFormat("Longest word is: {0} ", longestWord);
            bookStats.AppendLine();
            Console.WriteLine(bookStats.ToString(), "Book Info");
        }

        private static string[] FindTenMostCommon(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word
                                 into g
                                 orderby g.Count()
                          descending
                                 select g.Key;
            string[] commonWords = (frequencyOrder.Take(10)).ToArray();
            return commonWords;
        }
        private static string FindLongestWord(string[] words)
        {
            return (from w in words orderby w.Length descending select w).FirstOrDefault();
        }
    }
}
