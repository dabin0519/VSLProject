using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif 
using UnityEngine;
using UnityEngine.UIElements;

#if UNITY_EDITOR
public class JsonTOSO : EditorWindow
{
    private TextAsset _sheet;
    private string _soName;
    private string _savePath;

    /*[MenuItem("MddddyEditor/SheetToSO")]
    public static void OpenWindow()
    {
        var window = CreateWindow<JsonTOSO>("SheetToSO");
        window.Show();
    }*/

    private void OnGUI()
    {
        GUILayout.Label("SheetManager Editor", EditorStyles.boldLabel);

        GUILayout.Space(10);

        _soName = EditorGUILayout.TextField("SO Name", _soName);
        _savePath = EditorGUILayout.TextField("Save Path", _savePath);
        _sheet = EditorGUILayout.ObjectField("Sheet JSON", _sheet, typeof(TextAsset), false) as TextAsset;

        if (GUILayout.Button("Make SO"))
        {
            LoadJsonFile();
        }
    }

    private void LoadJsonFile()
    {
        /*if (_sheet == null)
        {
            Debug.LogError("�� ��Ʈ�־��");
        }

        string jsonContent = _sheet.text;

        // JSON ������ �Ľ�
        AllData allData = JsonUtility.FromJson<AllData>(jsonContent);

        // DialogListSO ����
        ScriptableObject dialogListSO = ScriptableObject.CreateInstance<DialogueSO>();

        // _dialogList ä���
        foreach (SheetData sheetData in allData.day3)
        {
            Dialog dialog = new Dialog();
            dialog.Name = sheetData.name;
            if (sheetData.type == "BasicType")
            {
                dialog.Type = DialogType.Default;
            }
            else
            {
                dialog.Type = DialogType.Question;
            }
            dialog.Description = sheetData.description;
            dialog.TypingSpeed = sheetData.speed / 10;
            dialog.CanSkip = sheetData.canSkip == "";

            dialogListSO.DialogsList.Add(dialog);
        }

        // ScriptableObject ����
        string path = "Assets/" + _savePath + _soName + ".asset";
        AssetDatabase.CreateAsset(dialogListSO, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();4
        */
    }
}
#endif

