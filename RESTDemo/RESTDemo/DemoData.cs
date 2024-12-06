using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTDemo
{
    public class Inventory
    {
        public int ItemId { get; set; }
        public string ItemType { get; set; }

        public Inventory (int Id, string Type)
        {
            ItemId = Id;
            ItemType = Type;
        }
    }
    public class DemoData
    {
        List<Inventory> InventoryList = new List<Inventory>();
        public DemoData()
        {
            InventoryList.Add(new Inventory(1, "Mobile"));
            InventoryList.Add(new Inventory(2, "Charger"));
        } 
        public void AddToList(int itemId, string itemType)
        {
            InventoryList.Add(new Inventory(itemId, itemType));
        }
        public List<Inventory> ShowList()
        {
            return InventoryList;
        }
    }
}
