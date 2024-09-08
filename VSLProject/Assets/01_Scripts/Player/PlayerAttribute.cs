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
    [SerializeField] private List<Stat> _statList; // �������� �ٲ����
    [SerializeField] private int _maxListCount;
    [SerializeField] private Transform _skillHolder;

    public void Initialize(Player player)
    {
        
    }

    private void Update()
    {
        if (_skillInfoList.Count != 0)
        {
            CalculateCoolTime();
        }
    }

    public void AddAttribute(Attribute attribute) 
    {
        Skill skill = attribute as Skill; 
        if (skill != null) // skill�� ��ȯ�� �Ǹ� skill �ƴϸ� stat
        {
            bool checker = true;

            foreach(var skillInfo in _skillInfoList)
            {
                if (skillInfo.skill == skill)
                {
                    skill.LevelUp();
                    checker = false;
                    break;
                }
            }
            if (checker)
            {
                AddSkill(skill);
            }    
        }
        Stat stat = attribute as Stat;
        if (stat != null)
        {
            // stat�� ���� �����ؾ��ϴµ� ��..
        }
    }

    private void CalculateCoolTime()
    {
        foreach(var skillInfo in _skillInfoList)
        {
            if (skillInfo.skill.OnSkillPropety) continue;
            if( skillInfo.coolTime >= skillInfo.skill.CoolTime)
            {
                skillInfo.skill.OnSkill();
                skillInfo.coolTime = 0;
            }
            else
            {
                skillInfo.coolTime += Time.deltaTime;
            }
        }
    }

    private void AddSkill(Skill skill)
    {
        Skill newSkill = Instantiate(skill, _skillHolder);
        _skillInfoList.Add(new SkillInfo(newSkill, 0));
    }
}
