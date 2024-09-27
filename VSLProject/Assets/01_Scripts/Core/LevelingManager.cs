using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingManager : MonoSingleton<LevelingManager>
{
    [SerializeField]
    [Tooltip("그냥 큰 수 넣어 여기서 베이스로 뽑아서 확률 계산할거임")]
    private int _baseRandomNum;

    // 나중에 구글 Sheet랑 연동해서 여기 있는 변수들 googleSheet에서 긁어오게 할 거임

    public int GetRandomIdx(int maxCnt)
    {
        //int randomNum = Random.Range(0, _baseRandomNum);

        return Random.Range(0, maxCnt);
    }
}
