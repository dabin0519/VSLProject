using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : HealthSystem, IPlayerComponent
{
    private Player _player;
    private PlayerAnimation _playerAnimation;

    public void Initialize(Player player)
    {
        _player = player;
        _playerAnimation = _player.GetCompo<PlayerAnimation>();
    }

    protected override void OnDamage(float damage)
    {
        base.OnDamage(damage);

        _playerAnimation.OnDamageAnimation();
    }

    public override void OnDie()
    {
        SceneManager.LoadScene(0);
    }
}
