using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : HealthSystem, IPlayerComponent
{
    private Player _player;
    private PlayerAnimation _playerAnimation;
    private PlayerStatSO _playerStat;

    public void Initialize(Player player)
    {
        _player = player;
        _playerAnimation = _player.GetCompo<PlayerAnimation>();
        _playerStat = _player.GetCompo<PlayerStat>().PlayerStatProperty;
    }

    protected override void Update()
    {
        base.Update();

        _maxHp = _playerStat.MaxHp;
    }

    protected override void OnDamage(float damage)
    {
        base.OnDamage(damage);

        _playerAnimation.OnDamageAnimation();
    }

    public override void OnDie()
    {
        Debug.LogWarning("이거 나중에 바꿔라");

        SceneManager.LoadScene(0);
    }
}
