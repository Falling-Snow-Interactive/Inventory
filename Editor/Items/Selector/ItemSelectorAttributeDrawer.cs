using System.Collections.Generic;
using Fsi.DataSystem.Selectors;
using Fsi.Inventory.Settings;
using UnityEditor;

namespace Fsi.Inventory.Items.Selector
{
    [CustomPropertyDrawer(typeof(ItemSelectorAttribute))]
    public class ItemSelectorAttributeDrawer : SelectorAttributeDrawer<string, ItemData>
    {
        protected override List<ItemData> GetEntries() => InventorySettings.Items;
    }
}