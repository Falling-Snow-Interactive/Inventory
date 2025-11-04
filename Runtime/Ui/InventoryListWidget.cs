using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fsi.Inventory.Ui
{
    public class InventoryListWidget : MonoBehaviour
    {
        private Action<InventoryEntryWidget> onInventoryEntryHighlighted;
        
        [Header("Prefab")]

        [SerializeField]
        private InventoryEntryWidget prefab;
        
        [Header("References")]
        
        [SerializeField]
        private Transform content;

        public List<InventoryEntryWidget> Entries { get; } = new();

        private void Awake()
        {
            Entries.Clear();
            for (int i = content.childCount - 1; i >= 0; i--)
            {
                Destroy(content.GetChild(i).gameObject);
            }
        }

        public void Initialize(List<InventoryEntry> entries, Action<InventoryEntryWidget> onEntryHighlighted)
        {
            onInventoryEntryHighlighted = onEntryHighlighted;

            ClearEntries();
            
            foreach (InventoryEntry entry in entries)
            {
                InventoryEntryWidget e = Instantiate(prefab, content);
                e.Initialize(entry, OnEntryHighlight);
                Entries.Add(e);
            }
        }

        private void ClearEntries()
        {
            foreach (InventoryEntryWidget e in Entries)
            {
                Destroy(e.gameObject);
            }

            Entries.Clear();
        }

        private void OnEntryHighlight(InventoryEntryWidget entry)
        {
            onInventoryEntryHighlighted?.Invoke(entry);
        }
    }
}
