using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : Attribute
{
    [SerializeField] protected float _coolTime;
    public float CoolTime => _coolTime;

    public abstract void OnSkill();
}
