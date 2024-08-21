using UnityEngine;

namespace BTVisual
{
    [System.Serializable]
    public class BlackBoard 
    {
        public Vector3 moveToPosition;
        public Vector3 lastSpotPosition;
        public LayerMask whatIsEnemy;
        public GameObject testGame;
    }
}
