
namespace CustomInterface
{
    interface IPointy
    {
       // byte GetNumberOfPoints();
        byte Points { get; }
    }
    interface IDraw3D
    {
        void Draw3D();
    }
}
