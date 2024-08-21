using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAttribute : MonoBehaviour
{
    public int level => _level;
    private int _level;

    public int maxLevel = 5;

    protected Transform _playerTrm;
    protected PlayerSkill _playerSkill;
    protected PlayerController _playerController;

    protected virtual void Awake()
    {
        _playerTrm = GameObject.Find("Player").transform;
        _playerController = _playerTrm.GetComponent<PlayerController>();
        _playerSkill = _playerTrm.GetComponent<PlayerSkill>();
    }

    public virtual void LevelUp(int value)
    {
        _level += value;
        Mathf.Clamp(_level, 0, maxLevel);
    }
}
