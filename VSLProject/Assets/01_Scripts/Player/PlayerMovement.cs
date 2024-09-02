using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private InputReader _inputReader;
    private PlayerStatSO _playerStatSO;

    public void Initialize(Player player)
    {
        _player = player;
        _inputReader = player.GetCompo<InputReader>();
        _playerStatSO = player.GetCompo<PlayerStatSO>();
    }

    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        Vector3 moveVec = _inputReader.Movement;
        transform.position += moveVec * _playerStatSO.moveSpeed * Time.fixedDeltaTime;
    }
}
