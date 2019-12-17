using System;

namespace ApplyingAttributes
{
    [Serializable]
    class Motorcycle
    {
        [NonSerialized]
        float weightOfCurrentPassengers;
        // Эти поля остаются сериализируемыми.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
}
