using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace ObgectContextApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Context *****\n");
            SportsCar sport = new SportsCar();
            Console.WriteLine();
            SportsCar sport1 = new SportsCar();
            Console.WriteLine();
            SportsCarTS synchroSport = new SportsCarTS();
            Console.ReadLine();
        }
    }

   // Класс SportsCar не имеет никаких специальных
    // контекстных потребностей и будет загружаться
    // в стандартный контекст домена приложения,
    class SportsCar
    {
        public SportsCar()
        {
            // Получить информацию о контексте и вывести идентификатор контекста.
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", 
                this.ToString(), ctx.ContextID);
            foreach( IContextProperty itfCtxProp in ctx.ContextProperties)
            {
                Console.WriteLine("-> Ctx Prop: {0}", itfCtxProp.Name);
            }
        }
    }

    // SportsCarTS требует загрузки в синхронизированный контекст
    [Synchronization]
    class SportsCarTS: ContextBoundObject
    {
        public SportsCarTS()
        {
            // Получить информацию о контексте и вывести идентификатор контекста.
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}",
                this.ToString(), ctx.ContextID);
            foreach (IContextProperty itfCtxProp in ctx.ContextProperties)
            {
                Console.WriteLine("-> Ctx Prop: {0}", itfCtxProp.Name);
            }
        }
    }
}
