using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotDolls.Models
{
    public class InventoryImage
    {
        public int InventoryImageId { get; set; }
        public int InventoryId { get; set; }
        public string Image { get; set; }

        //acts as a one to many
        public Inventory Inventory { get; set; }
    }
}
