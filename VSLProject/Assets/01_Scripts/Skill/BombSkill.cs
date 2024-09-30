using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : Skill
{
    [SerializeField] private PoolTypeSO _bombType;
    [SerializeField] private float _explosionRange; // ���� ����
    [SerializeField] private float _increaseRange; // �������� Ŀ�� ����

    public override void OnSkill()
    {
        base.OnSkill();

        SpawnBomb();
    }

    private void SpawnBomb()
    {
        var newBomb = PoolManager.Instance.Pop(_bombType);
        newBomb.GameObject.transform.position = _playerTrm.position;
        newBomb.GameObject.GetComponent<BombSkillVisual>().OnSkill(_explosionRange, _damageAmount);
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
