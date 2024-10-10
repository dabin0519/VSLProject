using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SheetManager : MonoBehaviour
{ 
    public List<EnemySheetInfo> enemySheetInfo;
    public PathInfoSO pathInfoSO;

    public Dictionary<Type, string> sheetDictionary = new Dictionary<Type, string>();


    public void SheetDataLoad()
    {
        StartCoroutine(LoadData());
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
        }
    }

    public string GetTSVAddress(string address, string range, long sheetID)
    {
        return $"{address}/export?format=tsv&range={range}&gid={sheetID}";
    }

    List<T> GetDatas<T>(string data)
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

    List<T> GetDatasAsChildren<T>(string data)
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

    T GetData<T>(string[] datas, string childType = "")
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
}