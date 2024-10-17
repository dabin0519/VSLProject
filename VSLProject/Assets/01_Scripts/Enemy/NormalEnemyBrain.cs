using BTVisual;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyBrain : EnemyBrain, IPoolable
{    
    private Pool _myPool;

    public override void Attack(System.Action AttackFinishEvent)
    {

    }

    public override void SetUpPool(Pool pool)
    {
        _myPool = pool;
    }
}
