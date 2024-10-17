using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    public List<PoolingItemSO> poolingItems;
    private Dictionary<PoolTypeSO, Pool> _pools;
    public PathInfoSO pathInfo;

    private void Awake()
    {
        _pools = new Dictionary<PoolTypeSO, Pool>();

        foreach(PoolingItemSO item in poolingItems)
        {
            IPoolable poolable = item.prefab.GetComponent<IPoolable>();
            Debug.Assert(poolable != null, $"Pool item does not have IPoolable interface {item.prefab.name}");

            Pool pool = new Pool(poolable, transform, item.initCount);
            _pools.Add(item.poolType, pool);
        }
    }

    public IPoolable Pop(PoolTypeSO type)
    {
        if(_pools.TryGetValue(type, out Pool pool)) 
            return pool.Pop();
        return null;
    }

    public void Push(IPoolable item)
    {
        if(_pools.TryGetValue(item.PoolType, out Pool pool)) 
            pool.Push(item);
    }
}
