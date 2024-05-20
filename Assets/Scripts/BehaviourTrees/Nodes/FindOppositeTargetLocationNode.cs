using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindOppositeTargetLocationNode : ActionNode
{
	public float walkRadius = 20f;
	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		UnityEngine.AI.NavMeshHit hit;
		UnityEngine.AI.NavMesh.SamplePosition(agent.transform.position*2 - treeData.TargetLocation, out hit, walkRadius, 1);
		Vector3 finalPosition = hit.position;
		treeData.TargetLocation = finalPosition;
		return State.Success;
	}
}




