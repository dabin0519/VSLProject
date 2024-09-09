using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[CustomEditor(typeof(SkillSelectUI))]
public class CustomSkillSelect : Editor
{
    private SkillSelectUI _skillSelect;

    private void OnEnable()
    {
        _skillSelect = target as SkillSelectUI;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Get all Attribute"))
        {
            UpdateAttribute();
        }
    }

    private void UpdateAttribute()
    {
        List<Attribute> loadedAttribute = new List<Attribute>();
        string[] assetGUIDs = AssetDatabase.FindAssets("", new[] { "Assets/03_Prefabs/Player" });

        foreach (string guid in assetGUIDs)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Attribute attribute = AssetDatabase.LoadAssetAtPath<Attribute>(assetPath);

            if (attribute != null)
            {
                loadedAttribute.Add(attribute);
            }
        }

        _skillSelect.attributeList = loadedAttribute;

        EditorUtility.SetDirty(_skillSelect);
        AssetDatabase.SaveAssets();
    }
}
