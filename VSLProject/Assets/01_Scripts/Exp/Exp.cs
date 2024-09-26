using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public float expAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerExp playerExp))
        {
            playerExp.IncreaseExp(expAmount);
            Destroy(gameObject);
        }
    }
}
