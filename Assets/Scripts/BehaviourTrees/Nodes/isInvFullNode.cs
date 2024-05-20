using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isInvFullNode : ActionNode
{

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(agent.GetComponent<NPCController>().items.Count >= agent.GetComponent<NPCController>().invCapacity){
			return State.Success;
		}
		return State.Failure;
	}
}




