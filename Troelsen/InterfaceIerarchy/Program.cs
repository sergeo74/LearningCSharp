using System;


namespace InterfaceIerarchy
{
    public interface IDrawable
    {
        void Draw();
    }
    public interface IAdvancedDraw: IDrawable
    {
        void DrowInBoundingBox(int top, int left, int bottom, int right);
        void DrowUpsideDown();
    }
    public class BitmapImage: IAdvancedDraw
    {
        public void Draw()
        {
            Console.WriteLine("Draw...");
        }
        public void DrowInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Drawing in a box...");
        }
        public void DrowUpsideDown()
        {
            Console.WriteLine("Drowing upside down...");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Interface Hieraarchy *****");
            //Вызвать на уровне объекта
            BitmapImage myBitmap = new BitmapImage();
            myBitmap.Draw();
            myBitmap.DrowInBoundingBox(10,10,10,10);
            myBitmap.DrowUpsideDown();

            //Получить IAdvancedDraw явным способом
            IAdvancedDraw iAdvDraw = myBitmap as IAdvancedDraw;
            if (iAdvDraw != null)
            {
                iAdvDraw.DrowUpsideDown();
            }
            if(myBitmap is IAdvancedDraw iAdvDraw1)
            {
                iAdvDraw1.DrowInBoundingBox(20, 20, 20, 20);
            }
            Console.ReadLine();
        }
    }
}
