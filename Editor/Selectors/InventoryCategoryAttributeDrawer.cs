using System;
using System.Collections.Generic;
using Fsi.DataSystem.Selectors;
using Fsi.Inventory.Settings;
using UnityEditor;

namespace Fsi.Inventory.Selectors
{
    // [CustomPropertyDrawer(typeof(InventoryCategoryAttribute))]
    public abstract class InventoryCategoryAttributeDrawer<TID> : SelectorAttributeDrawer<TID, InventoryCategory<TID>>
        where TID : Enum
    {
    }
}