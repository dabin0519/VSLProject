using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<PoolTypeSO> _enemyPoolTypes;
    [SerializeField] private Transform _playerTrm;
    [SerializeField] private float _spawnDistanceLimitX; 
    [SerializeField] private float _spawnDistanceLimitY;
    [SerializeField] private float _spawnPosOffset;

    [SerializeField] private EnemySpawnRateSO EnemySpawnRateSO;
    [SerializeField] private EnemyLevelSO[] _enemySheetDataList;

    private float _spawnCoolTime;
    private int _spawnAmount;
    private float _spawnTime;
    private int _level;
    private bool _oneCall;

    private void Awake()
    {
        LevelingManager.Instance.LevelChanged += OnLevelChanged;
    }

    private void OnLevelChanged(int level)
    {
        _spawnCoolTime = EnemySpawnRateSO.spawnRateDataList[level].spawnCoolTime;
        _spawnAmount = EnemySpawnRateSO.spawnRateDataList[level].spawnAmount;
        _level = level;
    }

    private void Update()
    {
        CalculateSpawnTime();
    }

    private void CalculateSpawnTime()
    {
        if(!_oneCall)
        {
            _spawnTime = _spawnCoolTime;
            _oneCall = true;
        }

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

        int randomIdx = LevelingManager.Instance.GetRandomIdx(_enemyPoolTypes.Count);
        var newEnemy = PoolManager.Instance.Pop(_enemyPoolTypes[randomIdx]);
        newEnemy.GameObject.transform.position = enemyPos;
        EnemyBrain enemy = newEnemy as EnemyBrain;
        EnemyLevelingInfo enemyData = _enemySheetDataList[randomIdx].enemyLevelingList[_level];

        if(enemy != null)
        {
            enemy.Init(enemyData.hp, enemyData.damage);
        }
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
