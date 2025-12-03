using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Spacer = Fsi.Ui.Dividers.Spacer;

namespace Fsi.Inventory.Settings
{
    public static class InventorySettingsProvider
    {
        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            SettingsProvider provider = new("Fsi/Inventory", SettingsScope.Project)
            {
                label = "Inventory",
                activateHandler = OnActivate,
            };
        
            return provider;
        }

        private static void OnActivate(string searchContext, VisualElement root)
        {
            root.style.marginTop = 5;
            root.style.marginRight = 5;
            root.style.marginLeft = 5;
            root.style.marginBottom = 5;
    
            SerializedObject settingsProp = InventorySettings.GetSerializedSettings();
        
            Label title = new("Inventory Settings");
            root.Add(title);
        
            root.Add(new Spacer());
        
            root.Add(new InspectorElement(settingsProp));
        
            root.Bind(settingsProp);
        }
    }
}