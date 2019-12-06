using System.Windows.Forms;


namespace CarLibrary
{
    public class SportCar : Car
    {
        public SportCar() { }
        public SportCar(string name, int maxSp, int currSp)
            : base(name, maxSp, currSp) { }
        public override void TurboBoost()
        {
            MessageBox.Show("Ramming speed!", "Faster is better....");
        }
    }

    public class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, int maxSp, int currSp)
            : base(name, maxSp, currSp) { }
        public override void TurboBoost()
        {
            // Минивэны имеют плохие возможности ускорения
            engineState = EngineState.engineDead;
            MessageBox.Show("Eeek!, Your engine block exploded!");
        }
    }
}
