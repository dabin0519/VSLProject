using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnSkill : Skill
{
    [SerializeField] protected PoolTypeSO _spawnPoolType;

    public override void OnSkill()
    {
        base.OnSkill();

        SpawnObject();
    }

    protected void SpawnObject()
    {
        var newObj = PoolManager.Instance.Pop(_spawnPoolType);
        InitObject(newObj.GameObject);
    }

    public abstract void InitObject(GameObject newObj);
}
