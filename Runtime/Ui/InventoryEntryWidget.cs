using System;
using Fsi.Inventory.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Fsi.Inventory.Ui
{
    public class InventoryEntryWidget : MonoBehaviour, ISelectHandler, IPointerEnterHandler
    {
        // Events 
        private Action<InventoryEntryWidget> onHighlight;
        
        public InventoryEntry Entry { get; private set; }
        
        [Header("References")]

        [SerializeField]
        private Image iconImage;

        [SerializeField]
        private TMP_Text nameText;

        [SerializeField]
        private TMP_Text amountText;

        [SerializeField]
        private Button button;

        public void Initialize(InventoryEntry entry, Action<InventoryEntryWidget> onHighlight = null)
        {
            this.onHighlight = onHighlight;

            Entry = entry;

            iconImage.sprite = entry.Item.Icon;
            nameText.text = entry.Item.Name;
            amountText.text = $"x{entry.Amount}";
        }

        public void OnSelect(BaseEventData eventData)
        {
            onHighlight?.Invoke(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onHighlight?.Invoke(this);
        }
    }
}
