using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : Skill
{
    [SerializeField] private float _explosionRange; // ���� ����
    [SerializeField] private float _increaseRange; // �������� Ŀ�� ����
    [SerializeField] private float _explosionTime; // ���߱��� �ɸ��� �ð�
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
        // ��..?
    }

    public override void SkillLevelUP()
    {
        _damageAmount++;
        _explosionRange += _increaseRange;
    }
}
