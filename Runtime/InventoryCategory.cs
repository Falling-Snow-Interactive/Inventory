using Fsi.DataSystem;
using UnityEngine;

namespace Fsi.Inventory
{
    [CreateAssetMenu(menuName = Menu + "Category", fileName = "New Inventory Category")]
    public class InventoryCategory : ScriptableData<string>
    {
        // Asset Menu
        private new const string Menu = ScriptableData<string>.Menu + "Inventory/";
        
        [Header("Visuals")]

        [SerializeField]
        private Sprite icon;
        public Sprite Icon => icon;
    }
}