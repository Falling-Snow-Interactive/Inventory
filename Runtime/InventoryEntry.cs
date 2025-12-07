using System;
using Fsi.Inventory.Items;
using Fsi.Inventory.Items.Selector;
using UnityEngine;

namespace Fsi.Inventory
{
    [Serializable]
    public class InventoryEntry<TID, TItem> : ISerializationCallbackReceiver
        where TID : Enum
        where TItem : ItemData<TID>
    {
        [HideInInspector]
        [SerializeField]
        private string name;
        
        [ItemSelector]
        [SerializeField]
        private TItem item;
        public TItem Item
        {
            get => item;
            set => item = value;
        }

        [Min(1)]
        [SerializeField]
        private int amount;
        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public InventoryEntry()
        {
            
        }

        public InventoryEntry(TItem item, int amount = 1)
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

        public override string ToString()
        {
            string s = "";
            if (item)
            {
                s = $"{item} - {amount}";
            }

            return s;
        }

        public void OnBeforeSerialize()
        {
            name = ToString();
        }

        public void OnAfterDeserialize() { }
    }
}