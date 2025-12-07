using System;
using Fsi.Inventory.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Fsi.Inventory.Ui
{
    public class InventoryPanelWidget<TID, TItem, TEntry, TInventory> : MonoBehaviour
        where TID : Enum
        where TItem : ItemData<TID>
        where TEntry : InventoryEntry<TID, TItem>, new()
        where TInventory : InventoryInstance<TID, TItem, TEntry>
    {
        private TInventory inventory;
        
        [Header("References")]

        [SerializeField]
        private InventoryListWidget<TID, TItem, TEntry, TInventory> inventoryListWidget;

        [SerializeField]
        private InventoryEntryInformationWidget<TID, TItem, TEntry> informationWidget;
        
        public void Initialize(TInventory inventory)
        {
            this.inventory = inventory;

            inventoryListWidget.Initialize(inventory.Entries, OnInventoryItemHighlight);
            if (inventoryListWidget.Entries.Count > 0)
            {
                EventSystem.current.SetSelectedGameObject(inventoryListWidget.Entries[0].gameObject);
            }
        }

        private void OnInventoryItemHighlight(InventoryEntryWidget<TID, TItem, TEntry> highlighted)
        {
            informationWidget.ShowInformation(highlighted.Entry);
        }
    }
}
