using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillInfo
{
    public Skill skill;
    public float coolTime;

    public SkillInfo(Skill skill, float coolTime)
    {
        this.skill = skill;
        this.coolTime = coolTime;
    }
}

public class PlayerAttribute : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private List<SkillInfo> _skillInfoList;
    [SerializeField] private List<Stat> _statList; // 스탯으로 바꿔야함
    [SerializeField] private int _maxListCount;
    [SerializeField] private Transform _skillHolder;

    public void Initialize(Player player)
    {
        
    }

    public void AddAttribute(Attribute attribute)
    {
        Skill skill = attribute as Skill;
        if (skill != null) // skill로 변환이 되면 skill 아니면 stat
        {
            _skillInfoList.Add(new SkillInfo(skill, Time.time));
        }
        Stat stat = attribute as Stat;
        if (stat != null)
        {
            // stat을 뭔가 변경해야하는데 음..
        }
    }

    private void Update()
    {
        CalculateCoolTime();
    }

    private void CalculateCoolTime()
    {
        foreach(var skillInfo in _skillInfoList)
        {
            if(Time.time - skillInfo.coolTime >= skillInfo.skill.CoolTime)
            {
                skillInfo.skill.OnSkill();
                skillInfo.coolTime = Time.time;
            }
        }
    }

}
