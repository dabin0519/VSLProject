using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTVisual
{
    public class SelectorNode : CompositeNode
    {
        private int _current = 0;

        protected override void OnStart()
        {
            _current = 0;
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            var child = children[_current];
            switch (child.Update())
            {
                case State.RUNNING:
                    return State.RUNNING;
                case State.SUCCESS:
                    return State.SUCCESS;
                case State.FAILURE:
                    _current++;
                    break;
            }

            return (_current == children.Count) ? State.FAILURE : State.RUNNING;
        }
    }
}
