using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attribute : MonoBehaviour
{
    public int level => _level;
    private int _level;

    public int maxLevel = 5;
    public PlayerAttributeSO attributeSO; 

    protected Transform _playerTrm;
    protected PlayerAttribute _playerSkill;
    protected PlayerMovement _playerMovement;

    protected virtual void Awake()
    {
        _playerTrm = GameObject.Find("Player").transform;
        _playerMovement = _playerTrm.GetComponent<PlayerMovement>();
        _playerSkill = _playerTrm.GetComponent<PlayerAttribute>();
    }

    public virtual void LevelUp(int value)
    {
        _level += value;
        Mathf.Clamp(_level, 0, maxLevel);
    }
}
