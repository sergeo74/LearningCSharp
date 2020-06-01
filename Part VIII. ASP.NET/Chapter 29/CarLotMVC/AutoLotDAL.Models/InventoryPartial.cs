using AutoLotDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.Models
{
    public partial class Inventory : EntityBase
    {
        [NotMapped]
        public string MakeColor => $"{Make}+ ({Color})";

        public override string ToString()
        {
            // Поскольку столбец PetName может быть пустым,
            // предоставить стандартное имя **No Name**.
            return $"{this.PetName ?? "**No Name**"} is a {this.Color} {this.Make}" +
                   $" with ID {this.Id}";
        }
    }

}
