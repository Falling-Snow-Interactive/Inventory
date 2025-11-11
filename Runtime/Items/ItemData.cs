using Fsi.DataSystem;
using Fsi.Inventory.Items.Selector;
using UnityEngine;

namespace Fsi.Inventory.Items
{
    [CreateAssetMenu(menuName = "Fsi/Items/Data", fileName = "New Item")]
    public class ItemData : ScriptableData<string>
    {
        [Header("Information")]

        [ItemCategorySelector]
        [SerializeField]
        private ItemCategory category;
        public ItemCategory Category => category;
        
        [Header("Visuals")]

        [SerializeField]
        private Sprite icon;
        public Sprite Icon => icon;

        [SerializeField]
        private Animator visuals;
        public Animator Visuals => visuals;
    }
}