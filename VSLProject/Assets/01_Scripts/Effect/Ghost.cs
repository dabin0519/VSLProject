using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour, IPoolable
{
    [field:SerializeField] public PoolTypeSO PoolType { get; private set; }
    [SerializeField] private float _ghostDuration;

    public GameObject GameObject => gameObject;

    private float _spawnTime;

    private void Update()
    {
        if(Time.time > _spawnTime + _ghostDuration)
        {
            PoolManager.Instance.Push(this);
        }
    }

    public void ResetItem()
    {
        _spawnTime = Time.time;
    }

    public void SetUpPool(Pool pool)
    {
        
    }
}
