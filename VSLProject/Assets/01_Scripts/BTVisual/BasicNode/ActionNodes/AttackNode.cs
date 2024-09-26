using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTVisual
{
    public class AttackNode : ActionNode
    {
        private bool _isFinishAttack;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            brain.MoveTo(Vector2.zero);
            brain.Attack(() =>
            {
                _isFinishAttack = true;
            });

            return _isFinishAttack ? State.SUCCESS : State.RUNNING;
        }
    }
}
