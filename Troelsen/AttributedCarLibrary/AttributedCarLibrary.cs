using System;

// Обеспечить совместимость с CLS для всех открытых типов в данной сборке.
[assembly: CLSCompliant(true)]

namespace AttributedCarLibrary
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct, Inherited = false)]
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        public VehicleDescriptionAttribute(string vehicalDescription)
        {
            Description = vehicalDescription;
        }
        public VehicleDescriptionAttribute() { }
    }

    // Назначить описание с помощью "именованного свойства".
    [Serializable]
    [VehicleDescription(vehicalDescription:"Му rocking Harley")]
    public class Motocycle
    {

    }

    [Serializable, Obsolete("Use another vehicle!")]
    [VehicleDescription(Description = "The old gray mare, she ain't what she used to be...")]
    public class HorseAndBuggy
    {

    }

    [VehicleDescription("A very long, slow, but feature-rich auto")]
    public class Winnebago
    {
        public ulong p;
    }
}
