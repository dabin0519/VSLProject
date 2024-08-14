using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public int statLevel;

    protected Transform _playerTrm;
    protected PlayerSkill _playerSkill;
    protected PlayerController _playerController;

    protected virtual void Awake()
    {
        _playerTrm = GameObject.Find("Player").transform;
        _playerController = _playerTrm.GetComponent<PlayerController>();
        _playerSkill = _playerTrm.GetComponent<PlayerSkill>();
    }
}
