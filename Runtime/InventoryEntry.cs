using System;
using Fsi.Inventory;
using UnityEngine;

namespace Fantazee.Inventories
{
    [Serializable]
    public class InventoryEntry<T> : ISerializationCallbackReceiver
        where T : IItem
    {
        [HideInInspector]
        [SerializeField]
        private string name;
        
        [SerializeField]
        private T value;
        public T Value => value;

        [SerializeField]
        private int amount;
        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public bool ShouldRemove => amount <= 0;

        public InventoryEntry(T value, int amount = 1)
        {
            this.value = value;
            this.amount = amount;
        }
        
        #region Object Overrides

        public override string ToString()
        {
            return value != null ? $"{value} x{amount}" : "No value";
        }
        
        #endregion
        
        #region Serialization

        public void OnBeforeSerialize()
        {
            name = ToString();
        }

        public void OnAfterDeserialize() { }
        
        #endregion
    }
}