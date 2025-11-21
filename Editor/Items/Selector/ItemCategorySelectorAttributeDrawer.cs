using System.Collections.Generic;
using Fsi.DataSystem.Selectors;
using Fsi.Inventory.Settings;
using UnityEditor;

namespace Fsi.Inventory.Items.Selector
{
    [CustomPropertyDrawer(typeof(ItemCategorySelectorAttribute))]
    public class ItemCategorySelectorAttributeDrawer : SelectorAttributeDrawer<ItemCategory, string>
    {
        protected override List<ItemCategory> GetEntries() => InventorySettings.ItemCategories;
    }
}