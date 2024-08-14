using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerStatSO _playerStatSO;

    private Vector2 _inputVector;

    // Property
    public Vector2 InputVector => _inputVector;

    protected override void Awake()
    {
        base.Awake();

        _inputReader.MovementEvent += SetMovement;
    }

    private void SetMovement(Vector2 value)
    {
        _inputVector = value;
    }

    private void FixedUpdate()
    {
        Vector3 moveVec = _inputVector;
        transform.position += moveVec * _playerStatSO.moveSpeed * Time.fixedDeltaTime;
    }
}
