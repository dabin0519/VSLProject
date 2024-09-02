using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerStatSO _playerStat; 

    private Dictionary<Type, IPlayerComponent> _components;

    private void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponent>();

        IPlayerComponent[] compoArr = GetComponentsInChildren<IPlayerComponent>();

        foreach(var component in compoArr)
        {
            _components.Add(component.GetType(), component);
        }

        _components.Add(_inputReader.GetType(), _inputReader);
        _components.Add(_playerStat.GetType(), _playerStat);

        foreach(var component in _components.Values)
        {
            component.Initialize(this);
        }
    }

    public T GetCompo<T>() where T : class
    {
        if (_components.TryGetValue(typeof(T), out IPlayerComponent compo))
        {
            return compo as T;
        }
        return default;
    }
}
