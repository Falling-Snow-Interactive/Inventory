using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Fsi.Inventory.Ui
{
    public class InventoryEntryInformationWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text nameText;

        [SerializeField]
        private Image sprite;

        [SerializeField]
        private TMP_Text amountText;

        [SerializeField]
        private TMP_Text descriptionText;

        public void ShowInformation(InventoryEntry inventoryEntry)
        {
            nameText.text = inventoryEntry.Item.Name;
            sprite.sprite = inventoryEntry.Item.Icon;
            amountText.text = $"x{inventoryEntry.Amount}";
            descriptionText.text = inventoryEntry.Item.Desc;
        }
    }
}
