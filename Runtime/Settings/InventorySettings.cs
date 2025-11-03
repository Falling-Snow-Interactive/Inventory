using System.Collections.Generic;
using Fsi.Inventory.Items;
using UnityEditor;
using UnityEngine;

namespace Fsi.Inventory.Settings
{
    public class InventorySettings : ScriptableObject
    {
        private const string ResourcePath = "Settings/InventorySettings";
        private const string FullPath = "Assets/Resources/" + ResourcePath + ".asset";

        private static InventorySettings settings;
        public static InventorySettings Settings => settings ??= GetOrCreateSettings();

        [Header("Library")]

        [SerializeField]
        private List<ItemData> items = new();
        public static List<ItemData> Items => Settings.items;

        [SerializeField]
        private List<ItemCategory> itemCategories = new();
        public static List<ItemCategory> ItemCategories => Settings.itemCategories;

        #region Settings

        private static InventorySettings GetOrCreateSettings()
        {
            InventorySettings settings = Resources.Load<InventorySettings>(ResourcePath);

            #if UNITY_EDITOR
            if (!settings)
            {
                if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }

                if (!AssetDatabase.IsValidFolder("Assets/Resources/Settings"))
                {
                    AssetDatabase.CreateFolder("Assets/Resources", "Settings");
                }

                settings = CreateInstance<InventorySettings>();
                AssetDatabase.CreateAsset(settings, FullPath);
                AssetDatabase.SaveAssets();
            }
            #endif

            return settings;
        }

        #if UNITY_EDITOR
        public static SerializedObject GetSerializedSettings()
        {
            return new SerializedObject(GetOrCreateSettings());
        }
        #endif

        #endregion
    }
}