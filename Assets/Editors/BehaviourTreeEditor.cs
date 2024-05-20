#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Linq.Expressions;
using UnityEditor.Callbacks;

public class BehaviourTreeEditor : EditorWindow
{
	BehaviourTreeView treeView;
	InspectorView inspectorView;

	[MenuItem("BehaviourTreeEditor/Editor ...")]
	public static void OpenWindow()
	{
		BehaviourTreeEditor wnd = GetWindow<BehaviourTreeEditor>();
		wnd.titleContent = new GUIContent("BehaviourTreeEditor");
	}

	[OnOpenAsset]
	public static bool OnOpenAsset(int instanceid, int line)
    {
		if (Selection.activeObject is BehaviourTree)
		{
			OpenWindow();
			return true;
		}
		return false;
    }

	public void CreateGUI()
	{
		VisualElement root = rootVisualElement;
		var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editors/BehaviourTreeEditor.uxml");
		visualTree.CloneTree(root);
		var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editors/BehaviourTreeEditor.uss");
		root.styleSheets.Add(styleSheet);

		treeView = root.Q<BehaviourTreeView>();
		inspectorView = root.Q<InspectorView>();
		treeView.OnNodeSelected = OnNodeSelectionChanged;
		OnSelectionChange();
	}

	private void OnSelectionChange()
	{
		BehaviourTree tree = Selection.activeObject as BehaviourTree;
		if (tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
		{
			treeView.PopulateView(tree);
		}
	}

	void OnNodeSelectionChanged(NodeView node)
	{
		inspectorView.UpdateSelection(node);
	}
}
#endif





