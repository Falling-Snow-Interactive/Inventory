using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fsi.Inventory.Settings
{
    public class InventorySettings<TID, TItem> : ScriptableObject
    {
        private const string ResourcePath = "Settings/InventorySettings";
        private const string FullPath = "Assets/Resources/" + ResourcePath + ".asset";

        private static InventorySettings<TID, TItem> settings;
        private static InventorySettings<TID, TItem> Settings => settings ??= GetOrCreateSettings();

        [Header("Libraries")]

        [SerializeField]
        private List<TItem> items = new();
        public static List<TItem> Items => Settings.items;

        [FormerlySerializedAs("itemCategories")]
        [SerializeField]
        private List<InventoryCategory<TID>> categories = new();
        public static List<InventoryCategory<TID>> Categories => Settings.categories;

        #region Settings

        private static InventorySettings<TID, TItem> GetOrCreateSettings()
        {
            InventorySettings<TID, TItem> s = Resources.Load<InventorySettings<TID, TItem>>(ResourcePath);

            #if UNITY_EDITOR
            if (!s)
            {
                if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }

                if (!AssetDatabase.IsValidFolder("Assets/Resources/Settings"))
                {
                    AssetDatabase.CreateFolder("Assets/Resources", "Settings");
                }

                s = CreateInstance<InventorySettings<TID, TItem>>();
                AssetDatabase.CreateAsset(s, FullPath);
                AssetDatabase.SaveAssets();
            }
            #endif

            return s;
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