using Fsi.DataSystem;
using Fsi.Inventory.Items.Selector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fsi.Inventory.Items
{
    [CreateAssetMenu(menuName = "Fsi/Items/Data", fileName = "New Item")]
    public class ItemData : ScriptableData<string>
    {
        [Header("Visuals")]

        [SerializeField]
        private Sprite icon;
        public Sprite Icon => icon;

        [FormerlySerializedAs("type")]
        [Header("Item")]

        [ItemCategorySelector]
        [SerializeField]
        private ItemCategory category;
        public ItemCategory Category => category;
    }
}