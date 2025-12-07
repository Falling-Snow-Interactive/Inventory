using System;
using Fsi.Inventory.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Fsi.Inventory.Ui
{
    public class InventoryEntryInformationWidget<TID, TItem, TEntry> : MonoBehaviour
        where TID : Enum
        where TItem : ItemData<TID>
        where TEntry : InventoryEntry<TID, TItem>
    {
    [SerializeField]
    private TMP_Text nameText;

    [SerializeField]
    private Image sprite;

    [SerializeField]
    private TMP_Text amountText;

    [SerializeField]
    private TMP_Text descriptionText;

    public void ShowInformation(TEntry inventoryEntry)
    {
        nameText.text = inventoryEntry.Item.Name;
        sprite.sprite = inventoryEntry.Item.Icon;
        amountText.text = $"x{inventoryEntry.Amount}";
        descriptionText.text = inventoryEntry.Item.Desc;
    }
    }
}
