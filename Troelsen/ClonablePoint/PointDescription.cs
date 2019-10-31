using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClonablePoint
{
    class PointDescription
    {
        public string PetName { get; set; }
        public Guid PointID { get;}
        public PointDescription()
        {
            PetName = "No-Name";
            PointID = Guid.NewGuid();
        }
    }
}
