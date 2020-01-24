using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Directory(Info) *****\n");
            //ShowWindowsDirectorylnfo();
            //ModifyAppDirectory();
            FunWithDirectoryType();
            Console.ReadLine();
        }
        static void ShowWindowsDirectorylnfo()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine($"FullName: {dir.FullName}");
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine($"Parent: {dir.Parent}");
            Console.WriteLine($"Creation: {dir.CreationTime}");
            Console.WriteLine($"Attributes: {dir.Attributes}");
            Console.WriteLine($"Root: {dir.Root}");
            Console.WriteLine("**************************\n");
        }
        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            Console.WriteLine("***** Modify Directory Info *****");
            dir.CreateSubdirectory("MyFolder");
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder2\Data");
            Console.WriteLine(myDataFolder);    
            Console.WriteLine("**************************\n");
        }
        static void FunWithDirectoryType()
        {
            string[] myDrives = Directory.GetLogicalDrives();
            foreach (string dr in myDrives)
            {
                Console.WriteLine("Here are your drives:");
                Console.WriteLine($"--> {dr}");

            }
            // Удалить ранее созданные подкаталоги.
            Console.WriteLine("Press Enter to delete directories");
            Console.ReadLine();
            try
            {
                Directory.Delete("MyFolder");
                // Второй параметр указывает, нужно ли удалять внутренние подкаталоги.
                Directory.Delete("MyFolder2", true);
            }
            catch (IOException e)
            {

                Console.WriteLine(e.Message);
            }

        }
    }
}
