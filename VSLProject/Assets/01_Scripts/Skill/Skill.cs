using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : Attribute
{
    [SerializeField] protected float _coolTime; // 스킬 쿨타임
    [SerializeField] protected float _duration; // 스킬 지속시간
    [SerializeField] protected float _damageAmount;

    protected Transform _playerTrm => GameManager.Instance.PlayerTrm;

    public float CoolTime => _coolTime;
    public float DamageAmount => _damageAmount;
    public bool OnSkillPropety => _onSkill;
    public AudioClip skillClip;

    protected bool _onSkill;
    private float _time;
    private PlayerStatSO _playerStat;
    private float _currentDuration;

    protected virtual void Awake()
    {
        _currentDuration = _duration;

        _time = _duration;
    }

    protected void Start()
    { 
        _playerStat = _playerTrm.GetComponent<Player>().GetCompo<PlayerStat>().PlayerStatProperty;
    }

    protected virtual void Update()
    {
        if(_onSkill)
        {
            CalculateDuration();
        }

        _duration = _currentDuration * _playerStat.skillDuration;
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
        SoundManager.Instance.PlaySFX(skillClip);
    }
    public abstract void SkillLevelUP();
    public abstract void OffSkill();
}
