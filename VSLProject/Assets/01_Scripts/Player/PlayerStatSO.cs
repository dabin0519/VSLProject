using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    MaxHp,
    AttackDamage,
    MoveSpeed,
    Defense,
    AttackRange, 
    CoolDown,
    SkillDuration,
    ExpMultiplier
}

[CreateAssetMenu(menuName = "SO/PlayerAttribute/PlayerStat")]
public class PlayerStatSO : PlayerAttributeSO
{
    public float moveSpeed;
    public float attackDamage;
    public float MaxHp;
    public float defense;
    public float attackRange;
    public float coolDown;       // 증가할수록 쿨타임 준다
    public float skillDuration;         // 증가할수록 스킬 지속시간 증가
    public float expMultiplier;         // 경험치 획득량 증가

    private Dictionary<StatType, float> _statDictionary;

    public static PlayerStatSO operator+(PlayerStatSO value1, PlayerStatSO value2)
    {
        value1.moveSpeed        += value2.moveSpeed;
        value1.attackDamage     += value2.attackDamage;
        value1.MaxHp            += value2.MaxHp;
        value1.defense          += value2.defense;
        value1.attackRange      += value2.attackRange;
        value1.coolDown         += value2.coolDown;
        value1.skillDuration    += value2.skillDuration;  
        value1.expMultiplier    += value2.expMultiplier;

        return value1;
    }

    public void InitDictionary()
    {
        _statDictionary = new Dictionary<StatType, float>
        {
            { StatType.MaxHp, MaxHp },
            { StatType.MoveSpeed, moveSpeed },
            { StatType.AttackDamage, attackDamage },
            { StatType.Defense, defense },
            { StatType.AttackRange, attackRange },
            { StatType.CoolDown, coolDown },
            { StatType.SkillDuration, skillDuration },
            { StatType.ExpMultiplier, expMultiplier }
        };
    }

    public void UpdateStatDictionary()
    {
        _statDictionary[StatType.MaxHp]             = MaxHp;
        _statDictionary[StatType.MoveSpeed]         = moveSpeed;
        _statDictionary[StatType.AttackDamage]      = attackDamage;
        _statDictionary[StatType.Defense]           = defense;
        _statDictionary[StatType.AttackRange]       = attackRange;
        _statDictionary[StatType.CoolDown]          = coolDown;
        _statDictionary[StatType.SkillDuration]     = skillDuration;
        _statDictionary[StatType.ExpMultiplier]     = expMultiplier;
    }

    public float GetStatValue(StatType type)
    {
        return _statDictionary[type];
    }
}
