using BTVisual;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyBrain : EnemyBrain 
{
    [SerializeField] private float _moveSpeed;

    private EnemyVisualController _enemyVisualController;
    private Vector3 _moveDir;
    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _enemyVisualController = transform.Find("Visual").GetComponent<EnemyVisualController>();
        target = GameObject.Find("Player");
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    public override void Attack()
    {

    }

    public override void MoveTo(Vector2 dir)
    {
        _moveDir = dir;
    }

    private void FixedUpdate()
    {
        transform.position += _moveDir * _moveSpeed * Time.fixedDeltaTime;

        if(_moveDir.x != 0)
        {
            _enemyVisualController.Flip(_moveDir.x < 0);
        }
    }
}
