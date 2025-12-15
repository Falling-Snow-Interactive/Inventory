using Fsi.DataSystem;
using Fsi.Inventory.Selectors;
using UnityEngine;

namespace Fsi.Inventory.Items
{
    // [CreateAssetMenu(menuName = Menu + "Data", fileName = "New Item Data")]
    public class ItemData<TID> : ScriptableData<TID>
    {
        private new const string Menu = ScriptableData<string>.Menu + "Items/";
        
        [Header("Visuals")]

        [SerializeField]
        private Animator visuals;
        public Animator Visuals => visuals;
        
        [Header("Information")]

        [InventoryCategory]
        [SerializeField]
        private InventoryCategory<TID> category;
        public InventoryCategory<TID> Category => category;
    }
}