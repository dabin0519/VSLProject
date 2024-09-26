using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTVisual
{
    public class CheckRangeNode : ActionNode
    {
        public int range;

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

            if(Vector2.Distance(brain.transform.position, brain.target.transform.position) < range )
            {
                return State.SUCCESS;
            }
            return State.FAILURE;
        }
    }
}
