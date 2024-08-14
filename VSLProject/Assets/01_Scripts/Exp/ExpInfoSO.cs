using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ExpInfo
{
    public Vector3 expPosition;     // ����ġ ������ 
    public float expAmount;         // ����ġ �� 
}

[CreateAssetMenu(menuName = ("SO/ExpInfo"))]
public class ExpInfoSO : ScriptableObject
{
    public List<ExpInfo> ExpInfo;
}