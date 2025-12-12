using System;
using Fsi.Inventory.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Fsi.Inventory.Ui
{
    public class InventoryEntryWidget<TID, TItem, TEntry> : MonoBehaviour, ISelectHandler, IPointerEnterHandler
        where TID : Enum
        where TItem : ItemData<TID>
        where TEntry : InventoryEntry<TID, TItem>
    {
        // Events 
        private Action<InventoryEntryWidget<TID, TItem, TEntry>> onHighlight;
        
        public TEntry Entry { get; private set; }
        
        [Header("References")]

        [SerializeField]
        private Image iconImage;

        [SerializeField]
        private TMP_Text nameText;

        [SerializeField]
        private TMP_Text amountText;

        [SerializeField]
        private Button button;

        public void Initialize(TEntry entry, Action<InventoryEntryWidget<TID, TItem, TEntry>> onHighlight = null)
        {
            this.onHighlight = onHighlight;

            Entry = entry;

            iconImage.sprite = entry.Item.Sprite;
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
