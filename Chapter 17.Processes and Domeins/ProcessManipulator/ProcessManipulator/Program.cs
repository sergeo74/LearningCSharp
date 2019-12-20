using System;
using System.Diagnostics;
using System.Linq;

namespace ProcessManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Processes *****\n");
            ListAllRunningProcesses();
            Console.ReadLine();
            GetSpecificProcess();
        }

        static void ListAllRunningProcesses()
        {
            var runningProcesses = from proc in Process.GetProcesses(".")
                                   orderby proc.Id
                                   select proc;
            foreach (var p in runningProcesses)
            {
                string info = $"-> PID: {p.Id}\tName: {p.ProcessName}";
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
        }

        // Если процесс с PID, равным 987, не существует,
        //то сгенерируется исключение во время выполнения
        static void GetSpecificProcess()
        {
            try
            {
                Process process = Process.GetProcessById(5132);
                Console.WriteLine(process.ProcessName);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            Console.ReadLine();
        }
    }
}
