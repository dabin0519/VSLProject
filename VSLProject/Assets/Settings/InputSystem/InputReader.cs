using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action<Vector2> MovementEvent;

    private Controls _playerInputAction;

    private void OnEnable()
    {
        if (_playerInputAction == null)
        {
            _playerInputAction = new Controls();
            _playerInputAction.Player.SetCallbacks(this);
        }

        _playerInputAction.Player.Enable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        MovementEvent?.Invoke(value);
    }
}

