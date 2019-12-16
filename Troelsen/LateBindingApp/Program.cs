using System;
using System.IO;
using System.Reflection;

namespace LateBindingApp
{
    // Это приложение будет загружать внешнюю сборку и
    // создавать объект, используя позднее связывание.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Late Binding  *****");
            Assembly a = TryLoadLocalAssembly();
            if (a != null)
                CreateUsingLateBinding(a);
            Console.ReadLine();
        }

        private static Assembly TryLoadLocalAssembly()
        {
            try
            {
                return Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        private static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                
                // Создать экземпляр MiniVan на лету!!!
                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine("Created a {0} using late binding!", obj);
                MethodInfo methodTurboBoost = miniVan.GetMethod("TurboBoost");
                methodTurboBoost.Invoke(obj, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
