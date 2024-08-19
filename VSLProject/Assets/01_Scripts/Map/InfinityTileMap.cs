using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityTileMap : MonoBehaviour
{
    [SerializeField] private float _limitXDistance;
    [SerializeField] private float _limitYDistance;
    [SerializeField] private Transform _playerTrm;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = _playerTrm.GetComponent<PlayerController>();
    }

    private void Update()
    {
        float dirX = (int)_playerController.InputVector.x;
        float dirY = (int)_playerController.InputVector.y;

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
