using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Linq.Expressions;

[CreateAssetMenu()]
public class BehaviourTree : ScriptableObject
{
	public Node rootNode;	
	public Node.State treeState = Node.State.Running;
	public List<Node> nodes = new List<Node>();
	public TreeData treeData = new TreeData();

	public Node.State Update(){
		if(rootNode.state == Node.State.Running){
			treeState = rootNode.Update();
		}
		return treeState;
	}
	public Node CreateNode(System.Type type){
		Node node = ScriptableObject.CreateInstance(type) as Node;
		node.name = type.Name;
#if UNITY_EDITOR
		node.guid = GUID.Generate().ToString();
#endif
		nodes.Add(node);

#if UNITY_EDITOR
		AssetDatabase.AddObjectToAsset(node, this);
		AssetDatabase.SaveAssets();
#endif
		return node;
	}

	public void DeleteNode(Node node){
        nodes.Remove(node);

        if (rootNode == node)
        {
            rootNode = null;

            if (nodes.Count > 0)
            {
                rootNode = nodes[0];
            }
        }
        nodes.Remove(node);
#if UNITY_EDITOR
		AssetDatabase.RemoveObjectFromAsset(node);
		AssetDatabase.SaveAssets();
#endif
	}

	public void AddChild(Node parent, Node child){
		DecoratorNode decorator = parent as DecoratorNode;
		if(decorator){
			decorator.child = child;
		}
		
		CompositeNode composite = parent as CompositeNode;
		if(composite){
			composite.children.Add(child);
		}

		RootNode rootNode = parent as RootNode;
		if(rootNode){
			rootNode.child = child;
		}
	}

	public void RemoveChild(Node parent, Node child){
		DecoratorNode decorator = parent as DecoratorNode;
		if(decorator){
			decorator.child = null;
		}
		
		CompositeNode composite = parent as CompositeNode;
		if(composite){
			composite.children.Remove(child);
		}

		RootNode rootNode = parent as RootNode;
		if(rootNode){
			rootNode.child = null;
		}
	}

	public List<Node> GetChildren(Node parent){
		List<Node> children = new List<Node>();
		DecoratorNode decorator = parent as DecoratorNode;
		if(decorator && decorator.child != null){
			children.Add(decorator.child);
		}

		RootNode rootNode = parent as RootNode;
		if(rootNode && rootNode.child != null){
			children.Add(rootNode.child);
		}
		
		CompositeNode composite = parent as CompositeNode;
		if(composite){
			return composite.children;
		}
		return children;
	}
	public void Traverse(Node node, System.Action<Node> visitor){
		if(node){
			visitor.Invoke(node);
			var children = GetChildren(node);
			children.ForEach((n) => Traverse(n, visitor));
		}
	}

	public BehaviourTree Clone(){
		BehaviourTree tree = Instantiate(this);
		tree.rootNode = tree.rootNode.Clone();
		return tree;
	}
	public void Bind(AiAgent agent){
		Traverse(rootNode, node => {
		node.agent = agent;
		node.treeData = treeData;
		});
	}
}


