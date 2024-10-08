using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IPoolable
{
    [field:SerializeField] public PoolTypeSO PoolType { get; protected set; }

    public GameObject GameObject => gameObject;

    protected Player _player;

    private void Start()
    {
        _player = GameManager.Instance.Player;
    }

    public void ResetItem()
    {
          
    }

    public void SetUpPool(Pool pool)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ItemTrigger();
            PoolManager.Instance.Push(this);
        }
    }

    public abstract void ItemTrigger();
}
