using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareDistancesNode : ActionNode
{
	public float DistanceThreshold;

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		float dist = Vector3.Distance(agent.transform.position, agent.Player.transform.position);
		if(dist < DistanceThreshold)
			return State.Success;
		return State.Failure;
	}
}




