using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.UI.Image;

public class ClosetAttackSkill : SpawnSkill
{
    [SerializeField] private float _checkEnemyRadius;
    [SerializeField] private LayerMask _whatIsEnemy;
    [SerializeField] private int _spawnCount = 0;

    private List<GameObject> _closetEnemyList;

    private int _spawnIdx = 0;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnSkill()
    {
        _spawnIdx = -1;
        GetClosetEnemy();

        base.OnSkill();
        //_closetEnemyList.Clear();
    }

    public override void InitObject(GameObject newObj)
    {
        _spawnIdx++;
        newObj.transform.position = transform.position;

        Bullet bullet = newObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            Vector3 target = _closetEnemyList[_spawnIdx] == null ? bullet.RandomDir() : _closetEnemyList[_spawnIdx].transform.position;
            Vector2 dir = target - transform.position;
            bullet.Init(dir, _damageAmount, false, _duration);
        }
    }

    protected override void SpawnObject()
    {
        for(int i = 0; i < _spawnCount; ++i)
        {
            base.SpawnObject();
        }
    }

    public override void OffSkill()
    {
        
    }

    public override void SkillLevelUP()
    {
        _spawnCount++;
    }

    private void GetClosetEnemy()
    {
        Vector2 origin = _playerTrm.position;
        List<RaycastHit2D> hitInfoList = Physics2D.CircleCastAll(origin, _checkEnemyRadius, Vector2.zero, 0, _whatIsEnemy).ToList();

        hitInfoList.Sort((a, b) => Vector2.Distance(origin, a.transform.position).CompareTo(Vector2.Distance(origin, b.transform.position)));

        Debug.Log("????");
        _closetEnemyList = new List<GameObject>(new GameObject[_spawnCount]);

        for (int i = 0; i < _spawnCount; ++i)
        {
            if (i >= hitInfoList.Count)
            {
                _closetEnemyList[i] = null;
            }
            else
            {
                _closetEnemyList[i] = hitInfoList[i].transform.gameObject;
            }
        }
    }
}
