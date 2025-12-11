using System;
using System.Collections.Generic;
using Fsi.Inventory.Items;
using UnityEngine;

namespace Fsi.Inventory
{
    [Serializable]
    public abstract class Inventory<TID, TItem, TEntry> //: Instance<TID, TItem>
        where TID : Enum
        where TItem : ItemData<TID>
        where TEntry : InventoryEntry<TID, TItem>, new()
    {
        [SerializeField]
        private List<TEntry> entries = new();
        public List<TEntry> Entries => entries;

        public bool TryGetItem(TItem item, out TEntry entry)
        {
            foreach (TEntry e in entries)
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
        
        public bool AddItem(TItem item, int amount = 1)
        {
            if (TryGetItem(item, out TEntry entry))
            {
                return entry.Add(amount);
            }

            entry = new TEntry
                    {
                        Item = item,
                        Amount = amount,
                    };
            entries.Add(entry);
            return true;
            
            // TODO - Add option for inventory size limit - Kira
        }

        public bool RemoveItem(TItem item, int amount = 1)
        {
            // TODO - Create key item type that can't just be removed. Ex: Quest items, keys, etc... - Kira
            
            if (TryGetItem(item, out TEntry entry))
            {
                return entry.Remove(amount);
            }

            Debug.LogWarning($"Inventory | Does not have {item.Name} to remove");
            return false;
        }

        // TODO - Cache this in a dictionary probably - Kira
        public List<TEntry> GetItemsOfType(InventoryCategory<TID> category)
        {
            List<TEntry> e = new();
            foreach (TEntry entry in entries)
            {
                if (entry.Item.Category == category)
                {
                    e.Add(entry);
                }
            }

            return e;
        }
    }
}
