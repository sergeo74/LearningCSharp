using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           // Kata kata = new Kata();
            Console.WriteLine(Kata.SquareDigits(9119));
            Console.ReadLine();
        }
    }
}
public class Kata
{
    public static int SquareDigits(int n)
    {
        string output = "";
        foreach (char c in n.ToString())
        {
            
            int square = int.Parse(c.ToString());
            output += (square * square).ToString();
            Console.WriteLine(output);
        }
        return int.Parse(output);
    }
}