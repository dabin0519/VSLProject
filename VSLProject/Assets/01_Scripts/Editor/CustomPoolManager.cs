using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PoolManager))]
public class CustomPoolManager : Editor
{
    private PoolManager _manager;

    private void OnEnable() {
        _manager = target as PoolManager;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Get all pool item")) 
        {
            UpdatePoolingItems();
        }
    }

    private void UpdatePoolingItems()
    {
        List<PoolingItemSO> loadedItems = new List<PoolingItemSO>();

        string path = _manager.pathInfo.poolPath;
        string[] assetGUIDs = AssetDatabase.FindAssets("", new []{path});

        foreach(string guid in assetGUIDs)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);  //Assets/08SO/Pool/Items/Bullet.asset
            PoolingItemSO item = AssetDatabase.LoadAssetAtPath<PoolingItemSO>(assetPath);
            
            if(item != null)
                loadedItems.Add(item);
        }

        _manager.poolingItems = loadedItems;

        EditorUtility.SetDirty(_manager);
        AssetDatabase.SaveAssets();
    }
}
