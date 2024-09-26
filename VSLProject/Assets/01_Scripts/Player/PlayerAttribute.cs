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

    private PlayerStatSO _playerStat;

    public void Initialize(Player player)
    {
        _playerStat = player.GetCompo<PlayerStat>().PlayerStatProperty;
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
        if (skill != null) // skill로 변환이 되면 skill 아니면 stat
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
            // stat을 뭔가 변경해야하는데 음..

            PlayerStatSO playerStatSO = stat.attributeSO as PlayerStatSO;
            if (playerStatSO != null)
            {
                if(stat.level != stat.maxLevel)
                    _playerStat += playerStatSO;
            }
            else
            {
                Debug.LogError("Something wrong");
            }
        }
    }

    private void CalculateCoolTime()
    {
        foreach(var skillInfo in _skillInfoList)
        {
            if (skillInfo.skill.OnSkillPropety) continue;
            if( skillInfo.coolTime <= 0)
            {
                skillInfo.skill.OnSkill();
                skillInfo.coolTime = skillInfo.skill.CoolTime - _playerStat.timeAccelration;
            }
            else
            {
                skillInfo.coolTime -= Time.deltaTime;
            }
        }
    }

    private void AddSkill(Skill skill)
    {
        Skill newSkill = Instantiate(skill, _skillHolder);
        _skillInfoList.Add(new SkillInfo(newSkill, 0));
    }
}
