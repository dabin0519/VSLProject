using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Player
{
    [SerializeField] private float _maxHp; // �̰� ���߿� ���� �����ؼ� �������� �������� �ٲ����
    [SerializeField] private HpBarUI _hpBarUI;
    [SerializeField] private float _testDamage;

    private float _currentHp;

    private void Start()
    {
        _currentHp = _maxHp;

        _hpBarUI.UpdateUI(_currentHp, _maxHp);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnDamage(_testDamage);
        }
    }

    private void OnDamage(float damage)
    {
        _currentHp -= damage;

        if (_currentHp <= 0)
        {
            // Die
        }

        _playerAnimation.OnDamageAnimation();
        _hpBarUI.UpdateUI(_currentHp ,_maxHp);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<Enemy>(out Enemy enemy))
        {
            OnDamage(enemy.GetDamage());
        }
    }
}
