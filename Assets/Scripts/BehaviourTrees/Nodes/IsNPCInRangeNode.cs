using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IsNPCInRangeNode : ActionNode
{
	public float range = 2f;

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		bool inRange = agent.CheckforNPCInRange(range);
		if (inRange) return State.Success;
		else return State.Failure;	
	}	
}








