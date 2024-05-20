using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class isAggressiveNode : ActionNode
{

	protected override void OnStart(){

	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(agent.aggressive) return State.Success;
		else return State.Failure;
	}
}









