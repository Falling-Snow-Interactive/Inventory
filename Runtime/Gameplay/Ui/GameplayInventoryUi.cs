using System;
using Fsi.Gameplay;
using Fsi.General;
using Fsi.Inventory.Ui;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Fsi.Inventory.Gameplay.Ui
{
    public class GameplayInventoryUi : MbSingleton<GameplayInventoryUi>
    {
        public static event Action<GameplayInventoryUi> InventoryUiOpened;
        public static event Action<GameplayInventoryUi> InventoryUiClosed;
        
        public bool IsOpen { get; private set; }
        
        [Header("Input")]
        
        [SerializeField]
        private InputActionReference inventoryActionRef;
        private InputAction inventoryAction;
        
        [Header("References")]

        [SerializeField]
        private InventoryPanelWidget inventoryPanelWidget;
        public InventoryPanelWidget InventoryPanelWidget => inventoryPanelWidget;
        
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
        
        public void OpenInventoryUI(Inventory inventory)
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
                OpenInventoryUI(InventoryManager.Instance.Inventory);
            }
        }
    }
}
