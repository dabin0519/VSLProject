using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ExpInfo
{
    public Exp expPefab;
    public float maxAmount;
}

public class SpawnExpSystem : MonoSingleton<SpawnExpSystem>
{
    [SerializeField] private List<ExpInfo> _expPrefabList;

    public void SpawnExp(Vector3 spawnPos, float expAmount)
    {
        Exp newExp = Instantiate(GetCorrectExpPrefab(expAmount), spawnPos, Quaternion.identity);
        newExp.expAmount = expAmount;
    }

    private Exp GetCorrectExpPrefab(float expAmount)
    {
        Exp currentExp = null;
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
