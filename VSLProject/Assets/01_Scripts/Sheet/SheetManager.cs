using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
#if UNITY_EDITOR
using Unity.EditorCoroutines.Editor;
using UnityEditor;

public class SheetManager : EditorWindow
{
    public List<EnemySheetInfo> enemySheetInfo;
    public List<ExpSheetInfo> expSheetInfo;

    public Dictionary<Type, string> sheetDictionary = new Dictionary<Type, string>();

    private Type[] _dropDownType = { typeof(EnemySheetInfo), typeof(ExpSheetInfo)}; // 여기서 선택할 타입을 정의
    private int _typeIndex = 0;
    private int _sheetInfoIdx;
    private PathInfoSO _pathInfoSO;
    private string _savePath;
    private SheetInfo _currentSheetInfo;

    private string _currentEnemyName;

    #region DataLoad Logic

    public void SheetDataLoad()
    {
        this.StartCoroutine(LoadData());
    }

    public IEnumerator LoadData()
    {
        List<Type> sheetTypes = new List<Type>(sheetDictionary.Keys);

        foreach (Type type in sheetTypes)
        {
            UnityWebRequest webRequest = UnityWebRequest.Get(sheetDictionary[type]);
            yield return webRequest.SendWebRequest();

            sheetDictionary[type] = webRequest.downloadHandler.text;

            if (type == typeof(EnemySheetInfo))
            {
                enemySheetInfo = GetDatasAsChildren<EnemySheetInfo>(sheetDictionary[type]);
            }
            else if(type == typeof(ExpSheetInfo))
            {
                expSheetInfo = GetDatasAsChildren<ExpSheetInfo>(sheetDictionary[type]);
            }
        }

        SheetToSO();
    }

    public string GetTSVAddress(string address, string range, long sheetID)
    {
        return $"{address}/export?format=tsv&range={range}&gid={sheetID}";
    }

    private List<T> GetDatas<T>(string data)
    {
        List<T> returnList = new List<T>();
        string[] splitedData = data.Split('\n');

        foreach (string element in splitedData)
        {
            string[] datas = element.Split('\t');
            returnList.Add(GetData<T>(datas));
        }

        return returnList;
    }

    private List<T> GetDatasAsChildren<T>(string data)
    {
        List<T> returnList = new List<T>();
        string[] splitedData = data.Split('\n');

        foreach (string element in splitedData)
        {
            string[] datas = element.Split('\t');
            returnList.Add(GetData<T>(datas, datas[0]));
        }

        return returnList;
    }

    private T GetData<T>(string[] datas, string childType = "")
    {
        object data;

        if (string.IsNullOrEmpty(childType) || Type.GetType(childType) == null)
        {
            data = Activator.CreateInstance(typeof(T));
        }
        else
        {
            data = Activator.CreateInstance(Type.GetType(childType));
        }

        FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        for (int i = 0; i < datas.Length; i++)
        {
            try
            {
                // string > parse
                Type type = fields[i].FieldType;

                if (string.IsNullOrEmpty(datas[i])) continue;

                if (type == typeof(int))
                    fields[i].SetValue(data, int.Parse(datas[i]));

                else if (type == typeof(float))
                    fields[i].SetValue(data, float.Parse(datas[i]));

                else if (type == typeof(bool))
                    fields[i].SetValue(data, bool.Parse(datas[i]));

                else if (type == typeof(string))
                    fields[i].SetValue(data, datas[i]);

                // enum
                else
                    fields[i].SetValue(data, Enum.Parse(type, datas[i]));
            }

            catch (Exception e)
            {
                Debug.LogError($"SpreadSheet Error : {e.Message}");
            }
        }

        return (T)data;
    }
    #endregion

    #region Editor Logic

    [MenuItem("MyEditor/SheetToSO")]
    public static void ShowWindow() 
    {
        var window = CreateWindow<SheetManager>("SheetToSO");
        window.Show();
    }

    public void OnGUI()
    {
        _pathInfoSO = (PathInfoSO)EditorGUILayout.ObjectField("Path Info SO", _pathInfoSO, typeof(PathInfoSO), false);

        _typeIndex = EditorGUILayout.Popup("Data Type", _typeIndex, GetAvailableTypeNames());

        _sheetInfoIdx = EditorGUILayout.IntField("Sheet Info Idx", _sheetInfoIdx);

        sheetDictionary = new();

        if (GUILayout.Button("SheetToSO"))
        {
            if(_pathInfoSO == null)
            {
                Debug.LogError("Path Info So 비워두면 안돼");
            }

            Type selectedType = _dropDownType[_typeIndex];

            _currentSheetInfo = _pathInfoSO.sheetInfoList[_sheetInfoIdx];
            string address = _pathInfoSO.sheetAddress;
            string range = _currentSheetInfo.range;
            long gid = _currentSheetInfo.gid;
            _savePath = _pathInfoSO.soSavePath;

            string tsvAddress = GetTSVAddress(address, range, gid);

            if (!sheetDictionary.ContainsKey(selectedType))
            {
                sheetDictionary.Add(selectedType, tsvAddress);
            }

            SheetDataLoad();
        }
    }

    private void SheetToSO()
    {
        if (enemySheetInfo != null)
        {
            EnemyLevelSO enemyDataSO = null;

            foreach (var sheetInfo in enemySheetInfo)
            {
                // 초기 상태거나 이름이 바뀌었을 경우 새로 SO만들기
                if (_currentEnemyName == string.Empty || sheetInfo.name != _currentEnemyName)
                {
                    // 이름이 바뀌었을 경우 이전꺼 저장
                    if (enemyDataSO != null)
                    {
                        SaveSO(enemyDataSO, _currentSheetInfo.saveFolderName, _currentEnemyName);
                    }

                    enemyDataSO = ScriptableObject.CreateInstance<EnemyLevelSO>();
                    _currentEnemyName = sheetInfo.name;
                    enemyDataSO.enemyName = _currentEnemyName;
                }

                EnemyLevelingInfo enemyInfo = new EnemyLevelingInfo();
                enemyInfo.level = sheetInfo.level;
                enemyInfo.hp = sheetInfo.hp;
                enemyInfo.damage = sheetInfo.damage;
                enemyDataSO.enemyLevelingList.Add(enemyInfo);
            }

            //SaveSO(enemyDataSO, );
        }
        if (expSheetInfo != null)
        {
            PlayerExpSO playerExpSO = ScriptableObject.CreateInstance<PlayerExpSO>();

            foreach (var sheetInfo in expSheetInfo)
            {
                playerExpSO.needExpAmountList.Add(sheetInfo.exp);
            }

            SaveSO(playerExpSO, _currentSheetInfo.saveFolderName, _currentSheetInfo.sheetName); 
        }
    }

    private void SaveSO(ScriptableObject so, string saveFolderName, string name)
    {
        _savePath = $"{_pathInfoSO.soSavePath}/Leveling/{saveFolderName}/{name}.asset";
        AssetDatabase.CreateAsset(so, _savePath);
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

    #endregion
}
#endif