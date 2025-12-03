using Fsi.DataSystem;
using Fsi.Inventory.Items.Selector;
using Fsi.Inventory.Selectors;
using UnityEngine;

namespace Fsi.Inventory.Items
{
    [CreateAssetMenu(menuName = Menu + "Data", fileName = "New Item Data")]
    public class ItemData : ScriptableData<string>
    {
        // Asset Menu
        private new const string Menu = ScriptableData<string>.Menu + "Items/";
        
        [Header("Visuals")]

        [SerializeField]
        private Sprite icon;
        public Sprite Icon => icon;

        [SerializeField]
        private Animator visuals;
        public Animator Visuals => visuals;
        
        [Header("Information")]

        [InventoryCategory]
        [SerializeField]
        private InventoryCategory category;
        public InventoryCategory Category => category;
    }
}