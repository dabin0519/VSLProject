using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoSingleton<ExpManager>
{
    [SerializeField] private ExpInfoSO _expInfoSO;

    private Transform _playerTransform;
    public Transform playerTrm => _playerTransform;

    private void Awake()
    {
        //_playerTransform = FindObjectOfType<PlayerController>().transform;
    }
}
