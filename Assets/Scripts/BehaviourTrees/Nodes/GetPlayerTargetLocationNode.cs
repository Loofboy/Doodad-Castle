using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerTargetLocationNode : ActionNode
{
	public float walkRadius = 20f;
	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(agent.Player == null) return State.Failure;

		UnityEngine.AI.NavMeshHit hit;
		UnityEngine.AI.NavMesh.SamplePosition(agent.Player.transform.position, out hit, walkRadius, 1);
		Vector3 finalPosition = hit.position;
		treeData.TargetLocation = finalPosition;
		return State.Success;
	}
}




