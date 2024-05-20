using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAtTargetLocationNode : ActionNode
{
	public float maxDist = 0.2f;

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(Vector3.Distance(agent.transform.position, treeData.TargetLocation) < maxDist) return State.Success;
		else return State.Failure;
	}
}




