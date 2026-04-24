using System;

namespace Fsi.Inventory
{
    [Serializable]
    public abstract class InventoryBase
    {
        public abstract InventoryGroup<IItem> Entries { get; }
        
        public abstract bool Contains<T>(T item) where T : IItem;
        public abstract bool Add<T>(T item) where T : IItem;
        public abstract bool Remove<T>(T item) where T : IItem;
        public abstract int Count();
        public abstract void Clean(bool force = false);
    }
}