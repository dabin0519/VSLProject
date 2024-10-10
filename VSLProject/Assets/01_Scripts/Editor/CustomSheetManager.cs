using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SheetManager))]
public class CustomSheetManager : Editor
{
    private Type[] _dropDownType = { typeof(EnemySheetInfo), }; // 여기서 선택할 타입을 정의
    private int _typeIndex = 0;
    private int _sheetInfoIdx;
    private PathInfoSO _pathInfoSO;
    private string _savePath;

    private string _currentName;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SheetManager sheetManager = (SheetManager)target;
        _pathInfoSO = sheetManager.pathInfoSO;

        _typeIndex = EditorGUILayout.Popup("dataType", _typeIndex, GetAvailableTypeNames());

        _sheetInfoIdx = EditorGUILayout.IntField("Sheet Info Idx", _sheetInfoIdx);

        if (GUILayout.Button("Data Load"))
        {
            Type selectedType = _dropDownType[_typeIndex];

            string address =    _pathInfoSO.sheetAddress;
            string range =      _pathInfoSO.sheetInfoList[_sheetInfoIdx].range;
            long gid =          _pathInfoSO.sheetInfoList[_sheetInfoIdx].gid;
            _savePath = _pathInfoSO.soSavePath;

            string tsvAddress = sheetManager.GetTSVAddress(address, range, gid);

            if(!sheetManager.sheetDictionary.ContainsKey(selectedType))
            {
                sheetManager.sheetDictionary.Add(selectedType, tsvAddress);
            }

            sheetManager.SheetDataLoad();
        }

        if (GUILayout.Button("SheetToSO"))
        {
            if (sheetManager.enemySheetInfo != null)
            {
                EnemyLevelSO enemyDataSO = null;

                foreach (var sheetInfo in sheetManager.enemySheetInfo)
                {
                    // 초기 상태거나 이름이 바뀌었을 경우 새로 SO만들기
                    if(_currentName == string.Empty || sheetInfo.name != _currentName) 
                    {
                        // 이름이 바뀌었을 경우 이전꺼 저장
                        if(enemyDataSO != null)
                        {
                            SaveSO(enemyDataSO);
                        }

                        enemyDataSO = ScriptableObject.CreateInstance<EnemyLevelSO>();
                        _currentName = sheetInfo.name;
                        enemyDataSO.enemyName = _currentName;
                    }

                    EnemyLevelingInfo enemyInfo = new EnemyLevelingInfo();
                    enemyInfo.level = sheetInfo.level;
                    enemyInfo.hp = sheetInfo.hp;
                    enemyInfo.damage = sheetInfo.damage;
                    enemyDataSO.enemyLevelingList.Add(enemyInfo);
                }

                SaveSO(enemyDataSO);
            }
        }
    }

    private void SaveSO(EnemyLevelSO enemyDataSO)
    {
        _savePath = $"{_pathInfoSO.soSavePath}/{_currentName}.asset";
        AssetDatabase.CreateAsset(enemyDataSO, _savePath);
        AssetDatabase.SaveAssets();
    }

    private string[] GetAvailableTypeNames()
    {
        string[] typeNames = new string[_dropDownType.Length];
        for (int i = 0; i < _dropDownType.Length; i++)
        {
            typeNames[i] = _dropDownType[i].Name;
        }
        return typeNames;
    }
}
