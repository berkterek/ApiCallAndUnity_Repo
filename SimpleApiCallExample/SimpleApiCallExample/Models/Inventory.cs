using System.Collections.Generic;

namespace SimpleApiCallExample.Models
{
    public class Inventory
    {
        public List<Item> Items { get; set; }
        public int Gold { get; set; }
        public int Gem { get; set; }
    }
}