using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    private int _damage;

    public int GetDamage()
    {
        return _damage;
    }
}
