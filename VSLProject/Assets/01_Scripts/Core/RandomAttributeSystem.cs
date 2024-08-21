using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomAttributeSystem : MonoSingleton<RandomAttributeSystem>
{
    [SerializeField] private List<PlayerAttribute> _attributeList;

    public PlayerAttribute RandomAttribute()
    {
        int randomIdx;
        do
        {
            randomIdx = Random.Range(0, _attributeList.Count);
        }
        while (_attributeList[randomIdx].level >= _attributeList[randomIdx].maxLevel); // 랜덤 속성을 뽑았는데 만약 속성에 최고레벨이면 아닐때까지 ㄱㄱ

        return _attributeList[randomIdx];
    }
}
