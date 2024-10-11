using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : HealthSystem, IPlayerComponent
{
    private Player _player;
    private PlayerAnimation _playerAnimation;
    private PlayerStatSO _playerStat;

    public bool isInvincibility;

    public void Initialize(Player player)
    {
        _player = player;
        _playerAnimation = _player.GetCompo<PlayerAnimation>();
        _playerStat = _player.GetCompo<PlayerStat>().PlayerStatProperty;
    }

    private void Start()
    {
        Init(_maxHp);
    }

    protected override void Update()
    {
        base.Update();

        _maxHp = _playerStat.MaxHp;
    }

    protected override void OnDamage(float damage)
    {
        if (isInvincibility) return;

        base.OnDamage(damage);

        _playerAnimation.OnDamageAnimation();
    }

    public void Heal(float heal)
    {
        _currentHp += heal;

        _hpBarUI.UpdateUI(_currentHp, _maxHp);
    }

    public override void OnDie()
    {
        Debug.LogWarning("이거 나중에 바꿔라");

        SceneManager.LoadScene(0);
    }
}
