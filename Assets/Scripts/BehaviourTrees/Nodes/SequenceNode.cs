using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SequenceNode : CompositeNode
{
	int current;
	
	protected override void OnStart(){
		current = 0;
	}

	protected override void OnStop(){
		
	}

	protected override State OnUpdate(){
		var child = children[current];

		switch(child.Update()){
			case State.Running:
				return State.Running;
			case State.Failure:
				return State.Failure;
			case State.Success:
				current++;
				break;
		}
		
		if(current == children.Count){
			Debug.Log("Finished all");
			return State.Success;
		}
		else{
			return State.Running;
		}
	}
}




