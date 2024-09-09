using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damage : MonoBehaviour
{
    public float damageAmount;

    public abstract void OffSkill();

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.TryGetComponent(out IDamageAble enemy))
        {
            enemy.GetDamage(damageAmount);
        }
    }
}
