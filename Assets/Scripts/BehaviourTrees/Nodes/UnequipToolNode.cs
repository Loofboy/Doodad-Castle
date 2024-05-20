using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnequipToolNode : ActionNode
{

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(treeData.assignedResource == null) return State.Failure;
		agent.GetComponentInChildren<PlayerToolUser>().UnEquipTool();
		return State.Success;
	}
}




