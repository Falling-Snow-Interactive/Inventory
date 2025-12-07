using System;
using Fsi.General;
using Fsi.Inventory.Items;
using Fsi.Inventory.Ui;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Fsi.Inventory.Gameplay.Ui
{
    public class GameplayInventoryWidget<TID, TItem, TEntry, TInventory> : MbSingleton<GameplayInventoryWidget<TID, TItem, TEntry, TInventory>>
        where TID : Enum
        where TItem : ItemData<TID>
        where TEntry : InventoryEntry<TID, TItem>, new()
        where TInventory : InventoryInstance<TID, TItem, TEntry>
    {
        public static event Action<GameplayInventoryWidget<TID, TItem, TEntry, TInventory>> InventoryUiOpened;
        public static event Action<GameplayInventoryWidget<TID, TItem, TEntry, TInventory>> InventoryUiClosed;
        
        public bool IsOpen { get; private set; }
        
        [Header("Input")]
        
        [SerializeField]
        private InputActionReference inventoryActionRef;
        private InputAction inventoryAction;
        
        [Header("References")]

        [SerializeField]
        private InventoryPanelWidget<TID, TItem, TEntry, TInventory> inventoryPanelWidget;
        public InventoryPanelWidget<TID, TItem, TEntry, TInventory> InventoryPanelWidget => inventoryPanelWidget;
        
        protected override void Awake()
        {
            base.Awake();
            inventoryPanelWidget.gameObject.SetActive(false);
            
            inventoryAction = inventoryActionRef.ToInputAction();

            IsOpen = false;
        }
        
        private void OnEnable()
        {
            // Inventory
            inventoryAction.Enable();
            inventoryAction.performed += OnInventoryActionPerformed;
        }

        private void OnDisable()
        {
            // Inventory
            inventoryAction.Disable();
            inventoryAction.performed += OnInventoryActionPerformed;
        }
        
        public void OpenInventoryUI(TInventory inventory)
        {
            Debug.Log("Inventory | Open UI", gameObject);
            
            inventoryPanelWidget.gameObject.SetActive(true);
            inventoryPanelWidget.Initialize(inventory);

            IsOpen = true;
            InventoryUiOpened?.Invoke(this);
        }

        public void CloseInventory()
        {
            Debug.Log("Inventory | Close UI", gameObject);
            inventoryPanelWidget.gameObject.SetActive(false);

            IsOpen = false;
            InventoryUiClosed?.Invoke(this);
        }
        
        // Input
        private void OnInventoryActionPerformed(InputAction.CallbackContext ctx)
        {
            if (IsOpen)
            {
                CloseInventory();
            }
            else
            {
                OpenInventoryUI(InventoryManager<TID, TItem, TEntry, TInventory>.Instance.Inventory);
            }
        }
    }
}
