using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotDolls.Models
{
    public class Geek
    {
        public int GeekId { get; set; }
        public string UserName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public DateTime Created_Date { get; set; }

        //acts as a one to many
        public ICollection<Inventory> Figurines { get; set; }
    }
}
