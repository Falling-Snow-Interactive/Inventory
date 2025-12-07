using System;
using System.Collections.Generic;
using Fsi.Inventory.Items;
using UnityEngine;

namespace Fsi.Inventory.Ui
{
    public class InventoryListWidget<TID, TItem, TEntry, TInventory> : MonoBehaviour
        where TID : Enum
        where TItem : ItemData<TID>
        where TEntry : InventoryEntry<TID, TItem>, new()
        where TInventory : InventoryInstance<TID, TItem, TEntry>
    {
        private Action<InventoryEntryWidget<TID, TItem, TEntry>> onInventoryEntryHighlighted;
        
        [Header("Prefab")]

        [SerializeField]
        private InventoryEntryWidget<TID, TItem, TEntry> prefab;
        
        [Header("References")]
        
        [SerializeField]
        private Transform content;

        public List<InventoryEntryWidget<TID, TItem, TEntry>> Entries { get; } = new();

        private void Awake()
        {
            Entries.Clear();
            for (int i = content.childCount - 1; i >= 0; i--)
            {
                Destroy(content.GetChild(i).gameObject);
            }
        }

        public void Initialize(List<TEntry> entries, Action<InventoryEntryWidget<TID, TItem, TEntry>> onEntryHighlighted)
        {
            onInventoryEntryHighlighted = onEntryHighlighted;

            ClearEntries();
            
            foreach (TEntry entry in entries)
            {
                InventoryEntryWidget<TID, TItem, TEntry> e = Instantiate(prefab, content);
                e.Initialize(entry, OnEntryHighlight);
                Entries.Add(e);
            }
        }

        private void ClearEntries()
        {
            foreach (InventoryEntryWidget<TID, TItem, TEntry> e in Entries)
            {
                Destroy(e.gameObject);
            }

            Entries.Clear();
        }

        private void OnEntryHighlight(InventoryEntryWidget<TID, TItem, TEntry> entry)
        {
            onInventoryEntryHighlighted?.Invoke(entry);
        }
    }
}
