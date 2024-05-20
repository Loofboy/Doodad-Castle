using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareDistancesTargetNode : ActionNode
{
	public float DistanceThreshold;

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		float dist = Vector3.Distance(agent.transform.position, treeData.TargetLocation);
		if(dist < DistanceThreshold)
			return State.Success;
		return State.Failure;
	}
}




