using System;

namespace ClonablePoint
{
    internal class PointDescription
    {
        public PointDescription()
        {
            PetName = "No-Name";
            PointID = Guid.NewGuid();
        }

        public string PetName { get; set; }
        public Guid PointID { get; }
    }
}