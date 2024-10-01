using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : SpawnSkill
{
    [SerializeField] private float _explosionRange; // ���� ����
    [SerializeField] private float _increaseRange; // �������� Ŀ�� ����

    public override void InitObject(GameObject newObj)
    {
        newObj.transform.position = _playerTrm.position;
        newObj.GetComponent<BombSkillVisual>().OnSkill(_explosionRange, _damageAmount);
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
