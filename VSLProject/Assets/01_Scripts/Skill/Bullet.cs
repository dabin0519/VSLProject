using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _offsetAngle;

    private Vector3 _moveDir;
    private float _damage;
    private CircleCollider2D _circleCollider;
    private float _startTime;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _startTime = Time.time;
    }

    public void Init(Vector2 dir, float damage)
    {
        _damage = damage;
        _moveDir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += _offsetAngle;

        transform.rotation = Quaternion.Euler(0,0, angle);
    }

    private void FixedUpdate()
    {
        transform.position += _moveDir * _moveSpeed * Time.fixedDeltaTime;

        if(Time.time - _startTime > 0.01f)
        {
            _circleCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.TryGetComponent(out IDamageAble damageAble))
        {
            damageAble.GetDamage(_damage);
        }
    }
}
