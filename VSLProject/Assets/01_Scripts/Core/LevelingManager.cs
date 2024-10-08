using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingManager : MonoSingleton<LevelingManager>
{
    [SerializeField]
    [Tooltip("�׳� ū �� �־� ���⼭ ���̽��� �̾Ƽ� Ȯ�� ����Ұ���")]
    private int _baseRandomNum;

    public int GetRandomIdx(int maxCnt) => Random.Range(0, maxCnt);
    public float GetPercentage() => ((float)GetRandomIdx(int.MaxValue) / int.MaxValue) * 100;
}
