using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    [SerializeField] private Color _hurtColor = Color.red;

    private IPoolable _enemyPool;
    private SpriteRenderer _spriteRenderer;
    private Color _defaultColor;

    private void Awake()
    {
        _spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
        _enemyPool = GetComponent<IPoolable>();
    }

    protected override void OnDamage(float damage)
    {
        _currentHp -= damage;

        if (_currentHp <= 0)
        {
            OnDie();
            return;
        }

        StartCoroutine(HurtAnimation());
        _hpBarUI.UpdateUI(_currentHp, _maxHp);
    }

    public override void OnDie()
    {
        SpawnExpSystem.Instance.SpawnExp(transform.position, 1f);
        PoolManager.Instance.Push(_enemyPool);
    }

    private IEnumerator HurtAnimation()
    {
        for(int i = 0; i < 3; ++i)
        {
            _spriteRenderer.DOColor(_hurtColor, 0.02f);
            yield return new WaitForSeconds(0.02f);
            _spriteRenderer.DOColor(_defaultColor, 0.02f);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
