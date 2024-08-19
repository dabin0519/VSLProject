using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTVisual
{
    public abstract class EnemyBrain : MonoBehaviour
    {
        public GameObject target;
        public abstract void Attack();
        public abstract void Move();
    }
}
