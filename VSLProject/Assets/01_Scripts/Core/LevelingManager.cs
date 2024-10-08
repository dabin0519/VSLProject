using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingManager : MonoSingleton<LevelingManager>
{
    [SerializeField]
    [Tooltip("그냥 큰 수 넣어 여기서 베이스로 뽑아서 확률 계산할거임")]
    private int _baseRandomNum;

    public int GetRandomIdx(int maxCnt) => Random.Range(0, maxCnt);
    public float GetPercentage() => ((float)GetRandomIdx(int.MaxValue) / int.MaxValue) * 100;
}
