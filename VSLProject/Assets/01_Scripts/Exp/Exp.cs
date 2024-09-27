using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour, IPoolable
{
    public float expAmount;

    public PoolTypeSO PoolType { get; private set; }
    public GameObject GameObject => gameObject;

    public void ResetItem()
    {
        
    }

    public void SetUpPool(Pool pool)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerExp playerExp))
        {
            playerExp.IncreaseExp(expAmount);
            Destroy(gameObject);
        }
    }
}
