using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipToolNode : ActionNode
{

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(treeData.assignedResource == null) return State.Failure;
		agent.EquipTool(treeData.assignedResource);
		agent.GetComponent<NPCController>().busy = true;
		return State.Success;
	}
}




