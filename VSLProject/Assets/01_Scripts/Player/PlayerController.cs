using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerStatSO _playerStat;

    private Vector2 _inputVector;

    // Property
    public Vector2 InputVector => _inputVector;

    private void Awake()
    {
        _inputReader.MovementEvent += SetMovement;
    }

    private void SetMovement(Vector2 value)
    {
        _inputVector = value;
    }

    private void FixedUpdate()
    {
        Vector3 moveVec = _inputVector;
        transform.position += moveVec * _playerStat.moveSpeed * Time.fixedDeltaTime;
    }
}
