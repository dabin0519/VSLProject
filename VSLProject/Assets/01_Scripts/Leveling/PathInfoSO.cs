using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SheetInfo
{
    public string sheetName;
    public string range;
    public int gid;
    public string saveFolderName;
}

[CreateAssetMenu(menuName = "SO/PathInfo")]
public class PathInfoSO : ScriptableObject
{
    public string poolPath;
    public string soSavePath;
    public string sheetAddress;
    public List<SheetInfo> sheetInfoList;
}
