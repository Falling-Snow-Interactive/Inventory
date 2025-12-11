using System;
using Fsi.DataSystem.Libraries;

namespace Fsi.Inventory.Items.Selector
{
    // [CustomPropertyDrawer(typeof(ItemSelectorAttribute))]
    public abstract class ItemLibraryAttributeDrawer<TID, TItem> : LibraryAttributeDrawer<TID, TItem>
        where TID : Enum
        where TItem : ItemData<TID>
    {
    }
}