using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBrain : MonoBehaviour, IPoolable
{
    public float moveSpeed;
    [SerializeField] protected float _damage;

    public GameObject target;

    [field:SerializeField] public PoolTypeSO PoolType { get; private set; }

    public GameObject GameObject => gameObject;

    private EnemyVisualController _enemyVisualController;
    private EnemyHealth _enemyHealth;
    private Vector3 _moveDir;

    protected void Awake()
    {
        _enemyVisualController = transform.Find("Visual").GetComponent<EnemyVisualController>();
        target = GameObject.Find("Player");
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    protected void FixedUpdate()
    {
        transform.position += _moveDir * moveSpeed * Time.fixedDeltaTime;

        if (_moveDir.x != 0)
        {
            _enemyVisualController.Flip(_moveDir.x < 0);
        }
    }

    public void MoveTo(Vector2 dir)
    {
        _moveDir = dir;
    }

    public void Init(float hp, float damage)
    {
        _damage = damage;
        _enemyHealth.Init(hp);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent(out IDamageAble damageAble))
        {
            damageAble.GetDamage(_damage);
        }
    }

    public abstract void Attack(Action AttackFinishEvent);

    public abstract void ResetItem();
    public abstract void SetUpPool(Pool pool);
}
