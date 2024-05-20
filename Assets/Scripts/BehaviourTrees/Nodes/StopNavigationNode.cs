using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StopNavigationNode : ActionNode
{
	protected override void OnStart(){

	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		agent.StopNav();
		return State.Success;
	}
}







