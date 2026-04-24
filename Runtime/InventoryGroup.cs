using System;
using System.Collections.Generic;
using System.Linq;
using Fantazee.Inventories;
using UnityEngine;

namespace Fsi.Inventory
{
    [Serializable]
    public class InventoryGroup<T>
        where T : IItem
    {
        [SerializeField]
        private List<InventoryEntry<T>> entries;
        public IReadOnlyList<InventoryEntry<T>> Entries => entries;

        public bool IsDirty { get; private set; }
        
        public InventoryGroup()
        {
            entries = new List<InventoryEntry<T>>();
        }

        public InventoryGroup(InventoryGroup<T> copy)
        {
            copy.Clean();
            entries = new List<InventoryEntry<T>>(copy.entries);
        }

        #region Contains
        
        public bool Contains(T item)
        {
            Clean();
            foreach (InventoryEntry<T> entry in entries)
            {
                if (entry.Value.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool Contains(T item, out InventoryEntry<T> entry)
        {
            Clean();
            foreach (InventoryEntry<T> e in entries)
            {
                if (e.Value.Equals(item))
                {
                    entry = e;
                    return true;
                }
            }

            entry = null;
            return false;
        }
        
        #endregion
        
        #region Add

        public bool Add(T item)
        {
            if (Contains(item, out InventoryEntry<T> entry))
            {
                entry.Amount++;
                return true;
            }

            entry = new InventoryEntry<T>(item);
            entries.Add(entry);
            IsDirty = true;
            return true;
        }

        public bool Add(T item, int count)
        {
            if (Contains(item, out InventoryEntry<T> entry))
            {
                entry.Amount += count;
                return true;
            }

            entry = new InventoryEntry<T>(item, count);
            entries.Add(entry);
            IsDirty = true;
            return true;
        }
        
        #endregion
        
        #region Remove

        public bool Remove(T item)
        {
            if (Contains(item, out InventoryEntry<T> entry))
            {
                entry.Amount--;
                if (entry.ShouldRemove)
                {
                    entries.Remove(entry);
                    IsDirty = true;
                }

                return true;
            }

            return false;
        }

        public bool Remove(T item, int amount)
        {
            if (Contains(item, out InventoryEntry<T> entry)
                && entry.Amount > amount)
            {
                entry.Amount -= amount;
                if (entry.ShouldRemove)
                {
                    entries.Remove(entry);
                    IsDirty = true;
                }

                return true;
            }

            return false;
        }
        
        #endregion

        #region Count

        // Count() or Count => ?
        public int Count()
        {
            Clean();
            int count = entries.Sum(x => x.Amount);
            return count;
        }

        #endregion

        #region Clean

        public void Clean(bool force = false)
        {
            if (IsDirty || force)
            {
                foreach (InventoryEntry<T> entry in new List<InventoryEntry<T>>(entries))
                {
                    if (entry.ShouldRemove)
                    {
                        entries.Remove(entry);
                    }
                }
            }

            IsDirty = false;
        }

        #endregion
    }
}