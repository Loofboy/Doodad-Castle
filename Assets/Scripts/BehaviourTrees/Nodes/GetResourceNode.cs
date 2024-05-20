using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResourceNode : ActionNode
{

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(agent.GetComponent<NPCController>().assignedResource == null) return State.Failure;
		treeData.assignedResource = agent.GetComponent<NPCController>().assignedResource;
		return State.Success;
	}
}




