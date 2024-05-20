#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using System;

public class NodeView : UnityEditor.Experimental.GraphView.Node
{
	public Action<NodeView> OnNodeSelected;
	public Node node;
	public Port input;
	public Port output;

	public NodeView(Node node)/* : base("Assets/Editors/NodeView.uxml")*/{
        focusable = true;

        this.node = node;
		this.title = node.name;
		this.viewDataKey = node.guid;
		style.left = node.position.x;
		style.top = node.position.y;

		CreateInputPorts();
		CreateOutputPorts();	
	}

	private void CreateInputPorts(){

		if(node is ActionNode){
			input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
		}

		else if(node is CompositeNode){
			input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
		}

		else if(node is DecoratorNode){
			input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
		}

		else if(node is RootNode){

		}

		if(input != null){
			input.portName = "";
			//input.style.flexDirection = FlexDirection.Column;
			inputContainer.Add(input);
		}
	}
	private void CreateOutputPorts(){
		
		if(node is ActionNode){
			
		}

		else if(node is CompositeNode){
			output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
		}

		else if(node is DecoratorNode){
			output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
		}

		else if(node is RootNode){
			output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
		}

		if(output != null){
			output.portName = "";
			//output.style.flexDirection = FlexDirection.ColumnReverse;
			outputContainer.Add(output);
		}
	}
	public override void SetPosition(Rect newPos){
		base.SetPosition(newPos);
		node.position.x = newPos.xMin;
		node.position.y = newPos.yMin;
	}
	public override void OnSelected(){
        Focus();
        base.OnSelected();
		if(OnNodeSelected != null){
			OnNodeSelected.Invoke(this);
		}
	}
}
#endif




