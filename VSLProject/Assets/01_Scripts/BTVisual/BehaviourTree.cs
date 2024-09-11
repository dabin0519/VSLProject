using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR

namespace BTVisual
{
    [CreateAssetMenu(menuName = "BehaviourTree/Tree")]
    public class BehaviourTree : ScriptableObject
    {
        public Node rootNode;
        public Node.State treeState = Node.State.RUNNING;
        public BlackBoard blackBoard  = new BlackBoard();
        public List<Node> nodes = new List<Node>();

        public void Bind(EnemyBrain brain)
        {
            Traverse(rootNode, n =>
            {
                n.blackBoard = blackBoard;
                n.brain = brain;
            });
        }

        public Node.State Update()
        {
            if (rootNode.state == Node.State.RUNNING)
            {
                treeState = rootNode.Update();
            }
            return treeState;
        }

#if UNITY_EDITOR
        public Node CreateNode(System.Type type)
        {
            var node = ScriptableObject.CreateInstance(type) as Node;
            node.name = type.Name;
            node.guid = GUID.Generate().ToString();

            Undo.RecordObject(this, "BT(CreateNode)");

            nodes.Add(node); // 만들어진 노드를 리스트에 넣는다.

            if (!Application.isPlaying)
            {
                AssetDatabase.AddObjectToAsset(node, this);
            }

            Undo.RegisterCreatedObjectUndo(node, "BT(CreateNode)");
            AssetDatabase.SaveAssets();

            return node;
        }

        public void DeleteNode(Node node)
        {
            Undo.RecordObject(this, "BT(DeleteNode)");
            nodes.Remove(node);
            //AssetDatabase.RemoveObjectFromAsset(node);
            Undo.DestroyObjectImmediate(node);
            AssetDatabase.SaveAssets();
        }
#endif
        public void AddChild(Node parent, Node child)
        {
            // 부모가 누군지에 따라 작동을 달리 해야해
            var decorator = parent as DecoratorNode;
            if (decorator != null)
            {
                Undo.RecordObject(decorator, "BT(AddChild)");
                decorator.child = child;
                EditorUtility.SetDirty(decorator);
                return;
            }

            var composite = parent as CompositeNode;
            if (composite != null)
            {
                Undo.RecordObject(composite, "BT(AddChild)");
                composite.children.Add(child);
                EditorUtility.SetDirty(composite);
                return;
            }


            var root = parent as RootNode;
            if (root != null)
            {
                Undo.RecordObject(root, "BT(AddChild)");
                root.child = child;
                EditorUtility.SetDirty(root);
            }
        }

        public void RemoveChild(Node parent, Node child)
        {
            var decorator = parent as DecoratorNode;
            if (decorator != null)
            {
                Undo.RecordObject(decorator, "BT(RemoveChild)");
                decorator.child = null;
                EditorUtility.SetDirty(decorator);
                return;
            }

            var composite = parent as CompositeNode;
            if (composite != null)
            {
                Undo.RecordObject(composite, "BT(RemoveChild)");
                composite.children.Remove(child);
                EditorUtility.SetDirty(composite);
                return;
            }

            var root = parent as RootNode;
            if (root != null)
            {
                Undo.RecordObject(root, "BT(RemoveChild)");
                root.child = null;
                EditorUtility.SetDirty(root);
                return;
            }
        }

        public List<Node> GetChildren(Node parent)
        {
            List<Node> children = new List<Node>();

            var composite = parent as CompositeNode;
            if (composite != null)
            {
                return composite.children;
            }

            var decorator = parent as DecoratorNode;
            if (decorator != null && decorator.child != null)
            {
                children.Add(decorator.child);
            }

            var root = parent as RootNode;
            if (root != null && root.child != null)
            {
                children.Add(root.child);
            }

            return children;
        }

        public void Traverse(Node node, System.Action<Node> visitor)
        {
            if (node)
            {
                visitor.Invoke(node);
                var children = GetChildren(node);
                children.ForEach(n => Traverse(n, visitor));
            }
        }

        public BehaviourTree Clone()
        {
            var tree = Instantiate(this);
            tree.rootNode = tree.rootNode.Clone();

            tree.nodes = new List<Node>();

            Traverse(tree.rootNode, n => 
            { 
                tree.nodes.Add(n);
            });

            return tree;
        }
    }
}
#endif