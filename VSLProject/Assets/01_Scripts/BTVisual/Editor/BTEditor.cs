using BTVisual;
using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class BTEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;
    
    private BehaviourTreeView _treeView;
    private InspectorView _inspectorView;

    private IMGUIContainer _blackboardView;
    private SerializedObject _treeObject;
    private SerializedProperty _blackboardProperty;

    [MenuItem("Window/BTEditor")]
    public static void OpenWindow()
    {
        BTEditor wnd = GetWindow<BTEditor>();
        wnd.titleContent = new GUIContent("BTEditor");
    }

    [OnOpenAsset]
    public static bool OnOpenAsset(int instanceId, int line)
    {
        if(Selection.activeObject is BehaviourTree)
        {
            OpenWindow();
            return true;
        }
        return false;
    }

    private void OnEnable()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStataeChanged;
        EditorApplication.playModeStateChanged += OnPlayModeStataeChanged;
    }

    private void OnDisable()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStataeChanged;
    }

    private void OnPlayModeStataeChanged(PlayModeStateChange state)
    {
        switch (state)
        {
            case PlayModeStateChange.EnteredEditMode:
                OnSelectionChange();
                break;
            case PlayModeStateChange.ExitingEditMode:
                break;
            case PlayModeStateChange.EnteredPlayMode:
                OnSelectionChange();
                break;
            case PlayModeStateChange.ExitingPlayMode:
                break;
        }
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        VisualElement template = m_VisualTreeAsset.Instantiate();
        template.style.flexGrow = 1;
        root.Add(template);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/01_Scripts/BTVisual/Editor/BTEditor.uss");
        root.styleSheets.Add(styleSheet);

        _treeView = root.Q<BehaviourTreeView>("tree-view");
        _inspectorView = root.Q<InspectorView>("inspector-view");
        _blackboardView = root.Q<IMGUIContainer>("blackboard");

        _blackboardView.onGUIHandler = () =>
        {
            if (_treeObject != null && _treeObject.targetObject != null)
            {
                _treeObject.Update();
                EditorGUILayout.PropertyField(_blackboardProperty);
                _treeObject.ApplyModifiedProperties();
            }
        };

        _treeView.OnNodeSelected += OnSelectionNodeChanged;

        OnSelectionChange(); // 강제로 호출해서
    }

    private void OnSelectionNodeChanged(NodeView nv)
    {
        _inspectorView.UpdateSelection(nv);
    }

    private void OnSelectionChange()
    {
        var tree = Selection.activeObject as BehaviourTree;

        if(tree == null) // 만약 선택된게 bt는 아니였지만 gameObject라면은 좀 다르게 동작해야해
        {
            if (Selection.activeGameObject) // 선택된게 게임오브젝트다
            {
                 var runner = Selection.activeGameObject.GetComponent<BehaviourTreeRunner>();

                if(runner != null)
                {
                    tree = runner.tree;
                }
            }
        }

        if (Application.isPlaying)
        {
            if(tree != null)
            {
                _treeView?.PopulateView(tree);
            }
            else
            {
                if(tree != null && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
                {
                    _treeView.PopulateView(tree);
                }
            }
        }

        if(tree != null && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
        {
            _treeView.PopulateView(tree);
        }

        if(tree != null)
        {
            _treeObject = new SerializedObject(tree);
            Debug.Log(_treeObject);
            _blackboardProperty = _treeObject.FindProperty("blackBoard");
            Debug.Log(_blackboardProperty);
        }
    }

    private void OnInspectorUpdate()
    {
        _treeView.UpdateNodeState();
    }
}