using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRoamTargetLocationNode : ActionNode
{
	public float walkRadius = 2f;
	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
		randomDirection += agent.transform.position;

		UnityEngine.AI.NavMeshHit hit;
		UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
		Vector3 finalPosition = hit.position;
		treeData.TargetLocation = finalPosition;
		return State.Success;
	}
}




