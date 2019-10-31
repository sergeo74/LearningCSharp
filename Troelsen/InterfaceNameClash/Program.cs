using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    #region Intrfaces
    public interface IDrawToForm
    {
        void Draw();
    }
    public interface IDrawToMemory
    {
        void Draw();
    }
    public interface IDrawToPrinter
    {
        void Draw();
    }
    #endregion
    class Octagon: IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Drawing the Octagon to form");
        }
        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Drawing the Octagon to memory");
        }
        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing the Octagon to printer");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Interface Clashes *****");

            Octagon oct = new Octagon();
            
            IDrawToForm itfForm = (IDrawToForm)oct;
            itfForm.Draw();
            
            //Сокращенная форма
            ((IDrawToMemory)oct).Draw();
            
            // Можно с is
            if(oct is IDrawToPrinter dtm) { dtm.Draw(); }
            
            Console.ReadLine();
        }
    }
}
