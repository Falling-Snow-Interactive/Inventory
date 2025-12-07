using Fsi.DataSystem;
using UnityEngine;

namespace Fsi.Inventory
{
    [CreateAssetMenu(menuName = Menu + "Category", fileName = "New Inventory Category")]
    public class InventoryCategory<TID> : ScriptableData<TID>
    {
        private new const string Menu = ScriptableData<string>.Menu + "Inventory/";
    }
}