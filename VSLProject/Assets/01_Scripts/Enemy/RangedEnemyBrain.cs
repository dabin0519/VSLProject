using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBrain : EnemyBrain
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _coolTime;
    [SerializeField] private int _attackTime = 3; // 한번에 공격 한느 수

    private Vector3 _moveDir;
    private bool _canAttack;
    private float _lastAttackTime;

    public override void Attack(System.Action AttackFinishEvent)
    {
        if (_canAttack)
        {
            _canAttack = false;
            _lastAttackTime = Time.time;
            for(int i = 0; i < _attackTime; ++i)
                Attack();
        }

        AttackFinishEvent?.Invoke();
    }

    private void Update()
    {
        if(!_canAttack)
        {
            if(Time.time > _lastAttackTime + _coolTime)
            {
                _canAttack = true;
            } 
        }
    }

    private void Attack()
    {
        Bullet newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        newBullet.Init(target.transform.position - transform.position, _damage);
        Destroy(newBullet.gameObject, 2f);
    }

    public override void ResetItem()
    {
        
    }

    public override void SetUpPool(Pool pool)
    {
        
    }
}
