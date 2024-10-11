using UnityEngine;
/*#if UNITY_EDITOR*/
namespace BTVisual
{
    public class BehaviourTreeRunner : MonoBehaviour
    {
        public BehaviourTree tree;
        private EnemyBrain _brain;

        private void Awake()
        {
            _brain = GetComponent<EnemyBrain>();
        }

        private void Start()
        {
            tree = tree.Clone();
            tree.Bind(_brain);
        }

        private void Update()
        {
            tree.Update();
        }
    }
}

/*#endif*/