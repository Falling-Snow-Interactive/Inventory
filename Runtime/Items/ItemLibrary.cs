using System;
using Fsi.DataSystem.Libraries;

namespace Fsi.Inventory.Items
{
    [Serializable]
    public class ItemLibrary<TID, TItem> : Library<TID, TItem>
        where TID : Enum
        where TItem : ItemData<TID>
    {
        
    }
}