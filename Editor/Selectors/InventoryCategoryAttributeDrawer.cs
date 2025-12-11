using System;
using System.Collections.Generic;
using Fsi.DataSystem.Libraries;
using Fsi.Inventory.Settings;
using UnityEditor;

namespace Fsi.Inventory.Selectors
{
    // [CustomPropertyDrawer(typeof(InventoryCategoryAttribute))]
    public abstract class InventoryCategoryAttributeDrawer<TID> : LibraryAttributeDrawer<TID, InventoryCategory<TID>>
        where TID : Enum
    {
    }
}