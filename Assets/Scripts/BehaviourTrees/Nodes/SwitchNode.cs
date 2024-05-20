using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwitchNode : CompositeNode
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
				current++;
				break;
			case State.Success:
				return State.Success;
		}

		
		if(current >= children.Count){
			return State.Failure;
		}
		else{
			return State.Running;
		}
	}
}







