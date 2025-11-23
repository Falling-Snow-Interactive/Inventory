using System;
using System.Collections.Generic;
using Fsi.Inventory.Items;
using UnityEngine;

namespace Fsi.Inventory
{
    [Serializable]
    public class Inventory
    {
        [SerializeField]
        private List<InventoryEntry> entries = new();
        public List<InventoryEntry> Entries => entries;

        public bool TryGetItem(ItemData item, out InventoryEntry entry)
        {
            foreach (InventoryEntry e in entries)
            {
                if (e.Item == item)
                {
                    entry = e;
                    return true;
                }
            }

            entry = null;
            return false;
        }
        
        public bool AddItem(ItemData item, int amount = 1)
        {
            if (TryGetItem(item, out InventoryEntry entry))
            {
                return entry.Add(amount);
            }

            entry = new InventoryEntry(item, amount);
            entries.Add(entry);
            return true;
            
            // TODO - Add option for inventory size limit - Kira
        }

        public bool RemoveItem(ItemData item, int amount = 1)
        {
            // TODO - Create key item type that can't just be removed. Ex: Quest items, keys, etc... - Kira
            
            if (TryGetItem(item, out InventoryEntry entry))
            {
                return entry.Remove(amount);
            }

            Debug.LogWarning($"Inventory | Does not have {item.Name} to remove");
            return false;
        }

        // TODO - Cache this in a dictionary probably - Kira
        public List<InventoryEntry> GetItemsOfType(InventoryCategory category)
        {
            List<InventoryEntry> entries = new();
            foreach (InventoryEntry entry in this.entries)
            {
                if (entry.Item.Category == category)
                {
                    entries.Add(entry);
                }
            }

            return entries;
        }
    }
}
