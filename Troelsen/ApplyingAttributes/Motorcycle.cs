using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
