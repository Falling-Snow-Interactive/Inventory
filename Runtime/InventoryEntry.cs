using System;
using Fsi.Inventory.Items;
using UnityEngine;

namespace Fsi.Inventory
{
    [Serializable]
    public class InventoryEntry
    {
        [SerializeField]
        private ItemData item;
        public ItemData Item => item;

        [Min(1)]
        [SerializeField]
        private int amount;
        public int Amount => amount;

        public InventoryEntry(ItemData item, int amount = 1)
        {
            this.item = item;
            this.amount = amount;
        }

        public bool Add(int amount = 1)
        {
            // TODO - Probably want to have a way to enforce inventory limits.

            this.amount += amount;
            return true;
        }

        public bool Remove(int amount = 1)
        {
            if (amount > this.amount)
            {
                Debug.LogWarning($"Inventory | {item.Name}");
                return false;
            }

            this.amount -= amount;
            return true;
        }
    }
}