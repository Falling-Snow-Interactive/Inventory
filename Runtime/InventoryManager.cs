using UnityEngine;

namespace Fsi.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private Inventory inventory;
        public Inventory Inventory => inventory;
    }
}
