using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ExpInfo
{
    public Vector3 expPosition;     // 경험치 포지션 
    public float expAmount;         // 경험치 량 
}

[CreateAssetMenu(menuName = ("SO/ExpInfo"))]
public class ExpInfoSO : ScriptableObject
{
    public List<ExpInfo> ExpInfo;
}
