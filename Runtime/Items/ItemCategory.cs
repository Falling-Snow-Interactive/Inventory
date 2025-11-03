using Fsi.DataSystem;
using UnityEngine;

namespace Fsi.Inventory.Items
{
    [CreateAssetMenu(menuName = "Fsi/Items/Category", fileName = "New Item Category")]
    public class ItemCategory : ScriptableData<string>
    {
        [Header("Visuals")]

        [SerializeField]
        private Sprite icon;
        public Sprite Icon => icon;
    }
}