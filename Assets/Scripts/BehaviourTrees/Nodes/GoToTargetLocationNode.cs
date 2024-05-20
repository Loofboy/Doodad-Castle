using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GoToTargetLocationNode : ActionNode
{
	protected override void OnStart(){

	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(treeData.TargetLocation == null || treeData.TargetLocation == Vector3.zero || !agent.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled) return State.Failure;
		agent.MoveToTarget(treeData.TargetLocation);
		return State.Success;
	}
}







