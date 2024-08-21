using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTVisual
{
    public class FollowTargetNode : ActionNode
    {
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if(brain.target == null)
                return State.FAILURE;

            Vector2 dir = brain.target.transform.position - brain.transform.position;

            brain.MoveTo(dir.normalized);

            return State.SUCCESS;
        }
    }
}
