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
        while (_attributeList[randomIdx].level >= _attributeList[randomIdx].maxLevel); // ���� �Ӽ��� �̾Ҵµ� ���� �Ӽ��� �ְ����̸� �ƴҶ����� ����

        return _attributeList[randomIdx];
    }
}
