using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAtDistanceFromPlayerNode : ActionNode
{
	public float DistanceThreshold;
	public float DistanceError;

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		float dist = Vector3.Distance(agent.transform.position, agent.Player.transform.position);
		if(dist < DistanceThreshold + DistanceError && dist > DistanceThreshold - DistanceError)
			return State.Success;
		return State.Failure;
	}
}




