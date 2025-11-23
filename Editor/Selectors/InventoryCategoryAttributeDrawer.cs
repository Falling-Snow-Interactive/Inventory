using System.Collections.Generic;
using Fsi.DataSystem.Selectors;
using Fsi.Inventory.Settings;
using UnityEditor;

namespace Fsi.Inventory.Selectors
{
    [CustomPropertyDrawer(typeof(InventoryCategoryAttribute))]
    public class InventoryCategoryAttributeDrawer : SelectorAttributeDrawer<string, InventoryCategory>
    {
        protected override List<InventoryCategory> GetEntries() => InventorySettings.ItemCategories;
    }
}