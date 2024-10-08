using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour, IPoolable, IDamageAble
{
    [SerializeField] private List<PoolTypeSO> _itemTypeList;

    [field:SerializeField] public PoolTypeSO PoolType {  get; private set; }

    public GameObject GameObject => gameObject;

    public void GetDamage(float damage)
    {
        var newObj = PoolManager.Instance.Pop(_itemTypeList[LevelingManager.Instance.GetRandomIdx(_itemTypeList.Count)]);
        newObj.GameObject.transform.position = transform.position;
        GameManager.Instance.DelayTime(0.2f, () => PoolManager.Instance.Push(this));
    }

    public void ResetItem()
    {
        
    }

    public void SetUpPool(Pool pool)
    {
        
    }
}
