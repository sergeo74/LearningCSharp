using AutoLotDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AutoLotDAL.Repos
{
    public class InventoryRepo : BaseRepo<Inventory>
    {
        public override List<Inventory> GetAll()
            => Context.Inventory.OrderBy(x => x.PetName).ToList();
    }
}
