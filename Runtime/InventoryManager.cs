using System;
using Fsi.General;
using Fsi.Inventory.Items;
using UnityEngine;

namespace Fsi.Inventory
{
    public class InventoryManager<TID, TItem, TEntry, TInventory> 
        : MbSingleton<InventoryManager<TID, TItem, TEntry, TInventory>>
        where TID : Enum
        where TItem : ItemData<TID>
        where TEntry : InventoryEntry<TID, TItem>, new()
        where TInventory : InventoryInstance<TID, TItem, TEntry>
    {
        [SerializeField]
        private TInventory inventory;
        public TInventory Inventory => inventory;

        public bool AddToInventory(TItem item, int amount)
        {
            return inventory.AddItem(item, amount);
        }

        public bool RemoveFromInventory(TItem item, int amount)
        {
            return inventory.RemoveItem(item, amount);
        }
    }
}
