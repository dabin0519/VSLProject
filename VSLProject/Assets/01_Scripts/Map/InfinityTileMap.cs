using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityTileMap : MonoBehaviour
{
    [SerializeField] private float _limitXDistance;
    [SerializeField] private float _limitYDistance;
    [SerializeField] private Transform _playerTrm;

    private Player _player;
    private InputReader _inputReader;

    private void Awake()
    {
        _player = _playerTrm.GetComponent<Player>();
    }

    private void Start()
    {
        _inputReader = _player.GetCompo<InputReader>();
    }

    private void Update()
    {
        float dirX = (int)_inputReader.Movement.x;
        float dirY = (int)_inputReader.Movement.y;

        if (Mathf.Abs(transform.position.x - _playerTrm.position.x) > _limitXDistance)
        {
            transform.Translate(Vector2.right * dirX * 40);
        }
        if (Mathf.Abs(transform.position.y - _playerTrm.position.y) > _limitYDistance)
        {
            transform.Translate(Vector2.up * dirY * 24);
        }
    }
}
