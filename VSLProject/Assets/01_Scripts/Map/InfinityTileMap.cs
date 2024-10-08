using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityTileMap : MonoBehaviour
{
    [SerializeField] private float _limitXDistance;
    [SerializeField] private float _limitYDistance;
    [SerializeField] private Transform _playerTrm;
    [SerializeField] private PoolTypeSO _graveType;

    private Transform _graveTrm;
    private Player _player;
    private InputReader _inputReader;

    private void Awake()
    {
        _player = _playerTrm.GetComponent<Player>();
        _graveTrm = transform.Find("GraveTrm");
    }

    private void Start()
    {
        _inputReader = _player.GetCompo<InputReader>();
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - _playerTrm.position.x) > _limitXDistance)
        {
            float offsetX = (_playerTrm.position.x - transform.position.x) > 0 ? _limitXDistance : -_limitXDistance;
            transform.position += new Vector3(offsetX * 2, 0);
            CheckSpawnGrave();
        }

        if (Mathf.Abs(transform.position.y - _playerTrm.position.y) > _limitYDistance)
        {
            CheckSpawnGrave();
            float offsetY = (_playerTrm.position.y - transform.position.y) > 0 ? _limitYDistance : -_limitYDistance;
            transform.position += new Vector3(0, offsetY * 2);
        }
    }

    private void CheckSpawnGrave()
    {
        if(LevelingManager.Instance.GetPercentage() < 5)
        {
            var newGrave = PoolManager.Instance.Pop(_graveType);
            newGrave.GameObject.transform.position = _graveTrm.position;
        }
    }
}
