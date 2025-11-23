using Fsi.General;
using Fsi.Inventory.Items;
using UnityEngine;

namespace Fsi.Inventory
{
    public class InventoryManager : MbSingleton<InventoryManager>
    {
        [SerializeField]
        private Inventory inventory;
        public Inventory Inventory => inventory;

        public virtual bool AddToInventory(ItemData item, int amount)
        {
            return inventory.AddItem(item, amount);
        }

        public virtual bool RemoveFromInventory(ItemData item, int amount)
        {
            return inventory.RemoveItem(item, amount);
        }
    }
}
