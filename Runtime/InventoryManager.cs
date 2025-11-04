using Fsi.Gameplay;
using UnityEngine;

namespace Fsi.Inventory
{
    public class InventoryManager : MbSingleton<InventoryManager>
    {
        [SerializeField]
        private Inventory inventory;
        public Inventory Inventory => inventory;
    }
}
