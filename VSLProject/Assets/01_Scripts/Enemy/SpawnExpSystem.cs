using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ExpInfo
{
    public PoolTypeSO expPefab;
    public float maxAmount;
}

public class SpawnExpSystem : MonoSingleton<SpawnExpSystem>
{
    [SerializeField] private List<ExpInfo> _expPrefabList;

    public void SpawnExp(Vector3 spawnPos, float expAmount)
    {
        var newExp = PoolManager.Instance.Pop(GetCorrectExpPrefab(expAmount));
        newExp.GameObject.transform.position = spawnPos;
        newExp.GameObject.GetComponent<Exp>().expAmount = expAmount;
    }

    private PoolTypeSO GetCorrectExpPrefab(float expAmount)
    {
        PoolTypeSO currentExp = null;
        int cnt = _expPrefabList.Count;

        for (int i = 0; i < _expPrefabList.Count; ++i)
        {
            if(i == cnt)
            {
                currentExp = _expPrefabList[cnt].expPefab;
                break;
            }
            if (_expPrefabList[i].maxAmount > expAmount)
            {
                currentExp = _expPrefabList[i].expPefab;
                break;
            }
        }

        return currentExp;
    }
}
