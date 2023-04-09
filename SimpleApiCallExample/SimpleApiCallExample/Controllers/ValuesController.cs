using SimpleApiCallExample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SimpleApiCallExample.Controllers
{
    public class ValuesController : ApiController
    {
        static List<string> _stringInventoryList = new List<string>
        {
            "Hat","Sword","Long Sword","Gun","Machine Gun"
        };

        static List<Item> _classInventoryList = new List<Item>
        {
            new Item{ID = 1,Name = "Hat",MagicValue = 0,ItemExtraValue = 0,ItemValue = 100},
            new Item{ID = 2,Name = "Sword",MagicValue = 2,ItemExtraValue = 0,ItemValue = 1},
            new Item{ID = 3,Name = "Long Sword",MagicValue = 10,ItemExtraValue = 0,ItemValue = 2},
            new Item{ID = 4,Name = "Gun",MagicValue = 0,ItemExtraValue = 0,ItemValue = 5},
            new Item{ID = 5,Name = "Machine Gun",MagicValue = 20,ItemExtraValue = 10,ItemValue = 50},
        };

        static Inventory _inventory = new Inventory
        {
            Items = _classInventoryList.ToList(),
            Gem = 10,
            Gold = 1000
        };

        [HttpGet]
        public List<string> GetAllStringInventoryListItems()
        {
            return _stringInventoryList.ToList();
        }

        [HttpGet]
        public string GetStringInventoryItemByItemIndex(int index)
        {
            try
            {
                return _stringInventoryList[index];
            }
            catch
            {
                return _stringInventoryList[0];
            }
        }

        [HttpPost]
        public void PostInventoyItem(string item)
        {
            _stringInventoryList.Add(item);
        }

        [HttpGet]
        public Item GetItem()
        {
            Item item = new Item
            {
                ID = 1,
                ItemExtraValue = 0,
                ItemValue = 10,
                MagicValue = 2,
                Name = "Magic Sword"
            };

            return item;
        }

        [HttpGet]
        public Inventory GetAllClassInventory()
        {
            return _inventory;
        }

        [HttpPost]
        public void PostItemToInventory(Item item)
        {
            _inventory.Items.Add(item);
        }

        [HttpPost]
        public void PostGoldGemValue(int gold, int gem)
        {
            _inventory.Gem = gem;
            _inventory.Gold = gold;
        }

        [HttpPost]
        public void PostGoldGemValue(Inventory inventory)
        {
            _inventory = inventory;
        }
    }
}