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
            //GetSpecificProcess();

            // Запросить у пользователя PID и вывести набор активных потоков.
            Console.WriteLine("***** Enter PID of process to investigate *****");
            string pID = Console.ReadLine();
            int theProcID = int.Parse(pID);
            EnumThreadsForPid(theProcID);
            EnumModsForPid(theProcID);
            Console.ReadLine();
            StartAndKillProcess();
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

        static void EnumThreadsForPid( int pID)
        {
            Process theProc;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
                //throw;
            }

            // Вывести статистические сведения по каждому потоку в указанном процессе.
            Console.WriteLine("Here are the threads used by: {0}", theProc.ProcessName);
            
            ProcessThreadCollection theThreads = theProc.Threads;
            foreach (ProcessThread processThread in theThreads)
            {
                string info =
                    $"-> Thread ID: {processThread.Id}" +
                    $"\tStart Time: {processThread.StartTime.ToShortTimeString()}" +
                    $"\tPriority: {processThread.PriorityLevel}";
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************");
        }

        static void EnumModsForPid(int pID)
        {
            Process theProc;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
                //throw;
            }

            // Вывести статистические сведения по каждому модулю в указанном процессе.
            Console.WriteLine("\nHere are the loaded modules for:: {0}", theProc.ProcessName);

            ProcessModuleCollection  theModules = theProc.Modules;
            foreach (ProcessModule procMod in theModules)
            {
                string info =
                    $"-> Module name: {procMod.ModuleName}";
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************");
        }

        static void StartAndKillProcess()
        {
            Process process = null;
            try
            {
                process = Process.Start("taskmgr.exe");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            Console.WriteLine("Hit any key to kill opera");
            Console.ReadLine();
            try
            {
                process.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            Console.ReadLine();
        }
    }
}
