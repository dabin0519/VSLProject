using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : SpawnSkill
{
    [SerializeField] private float _explosionRange; // 폭발 범위
    [SerializeField] private float _increaseRange; // 레벨업시 커질 범위

    public override void InitObject(GameObject newObj)
    {
        newObj.transform.position = _playerTrm.position;
        newObj.GetComponent<BombSkillVisual>().OnSkill(_explosionRange, _damageAmount);
    }

    public override void OffSkill()
    {
        // 음..?
    }

    public override void SkillLevelUP()
    {
        _damageAmount++;
        _explosionRange += _increaseRange;
    }
}
