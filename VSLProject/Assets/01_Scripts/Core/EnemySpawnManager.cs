using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private PoolTypeSO _enemyPoolType;
    [SerializeField] private Transform _playerTrm;
    [SerializeField] private float _spawnDistanceLimitX; 
    [SerializeField] private float _spawnDistanceLimitY;
    [SerializeField] private float _spawnPosOffset;
    [SerializeField] private GameObject _enemyPrefab; // 이거 나중에 적 interface로 바꾸시고요
    [SerializeField] private float _spawnAmount; // 음 이건 나중에 레벨링으로 돌릴듯?
    [SerializeField] private float _spawnCoolTime; // 이것도

    private float _spawnTime;

    private void Update()
    {
        CalculateSpawnTime();
    }

    private void CalculateSpawnTime()
    {
        if(_spawnTime < _spawnCoolTime)
        {
            _spawnTime += Time.deltaTime;
        }
        else
        {
            _spawnTime = 0;
            for(int i = 0; i < _spawnAmount; ++i)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        Vector3 enemyPos;
        do
        {
            Vector3 playerPos = _playerTrm.position;
            float enemyPosX = Random.Range(playerPos.x - _spawnDistanceLimitX - _spawnPosOffset,
                playerPos.x + _spawnDistanceLimitX + _spawnPosOffset);
            float enemyPosY = Random.Range(playerPos.y - _spawnDistanceLimitY - _spawnPosOffset,
                playerPos.y + _spawnDistanceLimitY + _spawnPosOffset);
            enemyPos = new Vector3(enemyPosX, enemyPosY);
        }
        while(CheckSpawnPosInPlayerRange(enemyPos));

        PoolManager.Instance.Pop(_enemyPoolType);
    }

    private bool CheckSpawnPosInPlayerRange(Vector3 pos)
    {
        Vector3 playerPos = _playerTrm.position;

        if (Mathf.Abs(pos.x - playerPos.x) < _spawnDistanceLimitX || 
            Mathf.Abs(pos.y - playerPos.y) < _spawnDistanceLimitY)
        {
            return true;
        }

        return false;
    }
}
