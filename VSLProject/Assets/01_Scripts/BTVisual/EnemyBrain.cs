using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBrain : MonoBehaviour
{
    public GameObject target;

    public abstract void Attack();
    public abstract void MoveTo(Vector2 dir);
}
