using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Fsi.Inventory.Ui
{
    public class InventoryPanelWidget : MonoBehaviour
    {
        private Inventory inventory;
        
        [Header("References")]

        [SerializeField]
        private InventoryListWidget inventoryListWidget;

        [SerializeField]
        private InventoryEntryInformationWidget informationWidget;
        
        public void Initialize(Inventory inventory)
        {
            this.inventory = inventory;

            inventoryListWidget.Initialize(inventory.Entries, OnInventoryItemHighlight);
            if (inventoryListWidget.Entries.Count > 0)
            {
                EventSystem.current.SetSelectedGameObject(inventoryListWidget.Entries[0].gameObject);
            }
        }

        private void OnInventoryItemHighlight(InventoryEntryWidget highlighted)
        {
            informationWidget.ShowInformation(highlighted.Entry);
        }
    }
}
