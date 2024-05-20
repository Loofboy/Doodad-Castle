using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLowHealthNode : ActionNode
{
	public int healthThreshold;

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(agent.health > healthThreshold)
			return State.Failure;
		else return State.Success;
	}
}



