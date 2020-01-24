using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLINQDataProcessingWithCancellation
{
    class Program
    {
        static CancellationTokenSource cancelToken = new CancellationTokenSource();
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Start any key to start processing");
                Console.ReadKey();
                Console.WriteLine("Porcessing");
                
                Task.Factory.StartNew(ProcessIntData);

                Console.Write("Enter Q to quit: ");
                string answer = Console.ReadLine();
                if (answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    cancelToken.Cancel();
                    break;
                }
            }
            while (true);
            Console.ReadLine();
        }

        static void ProcessIntData()
        {
            int[] source = Enumerable.Range(1, 100_000_000).ToArray();
            int[] modThreelsZero = null;

            // Найти числа, для которых истинно условие num % 3 == О,
            // и возвратить их в убывающем порядке.
            try
            {
                modThreelsZero = (from num in
                                  source.AsParallel()
                                  .WithCancellation(cancelToken.Token)
                                  where num % 3 == 0
                                  orderby num
                                  descending
                                  select num).ToArray();
                Console.WriteLine();
                Console.WriteLine($"Found {modThreelsZero.Count()} numbers that match query!");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
