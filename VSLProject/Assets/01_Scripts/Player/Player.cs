using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    private PlayerStatSO _playerStat;

    protected PlayerHealth      _playerHealth;
    protected PlayerSkill       _playerSkill;
    protected PlayerController  _playerController;
    protected PlayerAnimation   _playerAnimation;

    public PlayerStatSO playerStat => _playerStat;

    protected virtual void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerController = GetComponent<PlayerController>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }
}
