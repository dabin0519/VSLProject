using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : Attribute
{
    [SerializeField] protected float _coolTime; // 스킬 쿨타임
    [SerializeField] protected float _duration; // 스킬 지속시간
    [SerializeField] protected Transform _playerTrm;

    public float CoolTime => _coolTime;

    private bool _onSkill;
    private float _time;

    protected virtual void Update()
    {
        if(_onSkill)
        {
            CalculateDuration();
        }
    }

    private void CalculateDuration()
    {
        if(_time < _duration)
        {
            _time += Time.deltaTime;
        }
        else
        {
            _time = 0;
            _onSkill = false;
            OffSkill();
        }
    }

    public override void LevelUp()
    {
        base.LevelUp();

        SkillLevelUP();
    }

    public virtual void OnSkill()
    {
        _onSkill = true;
    }
    public abstract void SkillLevelUP();
    public abstract void OffSkill();
}
