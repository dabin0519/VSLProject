using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _offsetAngle;
    [field: SerializeField] public PoolTypeSO PoolType { get; private set; }

    public GameObject GameObject => gameObject;
    
    protected Vector3 _moveDir;
    private float _damage;
    private CircleCollider2D _circleCollider;
    private TrailRenderer _trailRenderer;
    private float _startTime;
    private float _spawnTime;
    private bool _playerAttack;
    private Pool _myPool;
    private float _duration;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
        _startTime = Time.time;
    }

    public void Init(Vector2 dir, float damage, bool playerAttack, float duration)
    {
        _spawnTime = Time.time;
        _moveDir = dir.normalized;
        _damage = damage;
        _playerAttack = playerAttack;
        _duration = duration;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += _offsetAngle;

        transform.rotation = Quaternion.Euler(0,0, angle);
    }

    public Vector2 RandomDir()
    {
        float angle = Random.Range(0f, 360f);
        Vector2 dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        return dir.normalized;
    }

    private void FixedUpdate()
    {
        transform.position += _moveDir * _moveSpeed * Time.fixedDeltaTime;

        if(Time.time - _startTime > 0.01f)
        {
            _trailRenderer.enabled = true;
            _circleCollider.isTrigger = true;
        }
        
        if(Time.time - _spawnTime > _duration)
        {
            _myPool.Push(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IDamageAble damageAble))
        {
            if(_playerAttack && collision.CompareTag("Player"))
            {
                damageAble.GetDamage(_damage);
            }
            else if(!_playerAttack && !collision.CompareTag("Player"))
            {
                damageAble.GetDamage(_damage);
            }
        }
    }

    public void SetUpPool(Pool pool)
    {
        _myPool = pool;
    }

    public void ResetItem()
    {
        _trailRenderer.enabled = false;
    }
}
