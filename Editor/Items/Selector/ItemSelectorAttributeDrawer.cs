using System;
using Fsi.DataSystem.Selectors;

namespace Fsi.Inventory.Items.Selector
{
    // [CustomPropertyDrawer(typeof(ItemSelectorAttribute))]
    public abstract class ItemSelectorAttributeDrawer<TID, TItem> : SelectorAttributeDrawer<TID, TItem>
        where TID : Enum
        where TItem : ItemData<TID>
    {
    }
}