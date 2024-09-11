using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : Skill
{
    [SerializeField] private float _explosionRange; // 폭발 범위
    [SerializeField] private float _increaseRange; // 레벨업시 커질 범위
    [SerializeField] private float _explosionTime; // 폭발까지 걸리는 시간
    [SerializeField] private BombSkillVisual _bombPrefab;

    public override void OnSkill()
    {
        base.OnSkill();

        SpawnBomb();
    }

    private void SpawnBomb()
    {
        BombSkillVisual newBomb = Instantiate(_bombPrefab, _playerTrm.position, Quaternion.identity);
        newBomb.OnSkill(_explosionRange, _explosionTime, _damageAmount);
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
