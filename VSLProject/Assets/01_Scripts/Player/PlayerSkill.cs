using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private List<Skill> _skillList; // gameObject 나중에 바꿔줄듯? 스킬로?
    [SerializeField] private List<Stat> _statList; // 스탯으로 바꿔야함
    [SerializeField] private int _maxListCount;

    public void AddStat(Stat value)
    {
        if (_statList.Count >= _maxListCount)
            return;

        foreach(var stat in _statList)
        {
            if(stat == value)
            {
                stat.statLevel++;
                return;
            }
        }

        _statList.Add(value);
    }

    public void AddSkill(Skill value)
    {
        if (_skillList.Count >= _maxListCount)
            return;

        foreach (var skill in _skillList)
        {
            if (skill == value)
            {
                skill.skillLevel++;
                return;
            }
        }

        _skillList.Add(value);
    }
}
