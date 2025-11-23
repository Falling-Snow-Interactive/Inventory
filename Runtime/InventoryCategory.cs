using Fsi.DataSystem;
using UnityEngine;

namespace Fsi.Inventory
{
    [CreateAssetMenu(menuName = "Fsi/Inventory/Category", fileName = "New Inventory Category")]
    public class InventoryCategory : ScriptableData<string>
    {
        [Header("Visuals")]

        [SerializeField]
        private Sprite icon;
        public Sprite Icon => icon;
    }
}