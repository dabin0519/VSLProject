using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField] protected float _maxHp;
    [SerializeField] protected HpBarUI _hpBarUI;

    protected float _currentHp;

    private void Start()
    {
        _currentHp = _maxHp;

        _hpBarUI.UpdateUI(_currentHp, _maxHp);
    }

    protected virtual void OnDamage(float damage)
    {
        _currentHp -= damage;

        if (_currentHp <= 0)
        {
            OnDie();
        }

        _hpBarUI.UpdateUI(_currentHp, _maxHp);
    }

    public abstract void OnDie();
}
