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
            Debug.LogError("야 시트넣어라");
        }

        string jsonContent = _sheet.text;

        // JSON 데이터 파싱
        AllData allData = JsonUtility.FromJson<AllData>(jsonContent);

        // DialogListSO 생성
        ScriptableObject dialogListSO = ScriptableObject.CreateInstance<DialogueSO>();

        // _dialogList 채우기
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

        // ScriptableObject 저장
        string path = "Assets/" + _savePath + _soName + ".asset";
        AssetDatabase.CreateAsset(dialogListSO, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();4
        */
    }
}
#endif

