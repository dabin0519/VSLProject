using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BTVisual
{
    public class MoveRandomPosNode : ActionNode
    {
        public float runDistance;

        private Vector2 _dir;
        private float _currentSpeed;

        protected override void OnStart()
        {
            Debug.Log("??");
            Vector2 dir = brain.target.transform.position - brain.transform.position;
            _dir = -dir;

            _currentSpeed = brain.moveSpeed;

            brain.moveSpeed *= 1.5f; // 현재 속도에서 빠르게 도망가고
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            Vector2 currentPos = brain.transform.position;

            float distance = Vector2.Distance(currentPos, brain.target.transform.position);
            Debug.Log(distance);

            if (distance > runDistance)
            {
                brain.moveSpeed = _currentSpeed; // 속도 다시 셋팅
                return State.SUCCESS;
            }
            else
            {
                brain.MoveTo(_dir);

                return State.RUNNING;
            }
        }
    }
}
