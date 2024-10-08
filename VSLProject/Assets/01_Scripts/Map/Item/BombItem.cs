using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : Item
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _whatIsEnemy;

    public override void ItemTrigger()
    {
        RaycastHit2D[] hitInfos = Physics2D.CircleCastAll(transform.position, _radius, Vector2.zero, 0, _whatIsEnemy);
        foreach(var hitInfo in hitInfos)
        {
            if(hitInfo.transform.TryGetComponent(out IDamageAble damageAble))
            {
                damageAble.GetDamage(int.MaxValue);
            }
        }
    }
}
