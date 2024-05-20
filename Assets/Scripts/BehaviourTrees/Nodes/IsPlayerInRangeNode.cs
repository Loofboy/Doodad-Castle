using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerInRangeNode : ActionNode
{
	public float range = 2f;

	protected override void OnStart(){

	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(agent.Player == null) return State.Failure;
		bool inRange = agent.CheckforPlayerInRange(range);
		if (inRange) return State.Success;
		else return State.Failure;
	}
}





