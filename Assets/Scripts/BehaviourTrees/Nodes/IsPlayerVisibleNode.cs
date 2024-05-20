using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerVisibleNode : ActionNode
{
	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){

		if(agent.Player == null) return State.Failure;
        RaycastHit hit;
        var rayDirection = agent.Player.transform.position - agent.transform.position;

		if (Physics.Raycast (agent.transform.position, rayDirection, out hit)) {
			if (hit.transform.gameObject.layer == 8) {
				return State.Success;
			} else {
				return State.Failure;
			}
    	}
		return State.Failure;
	}
}




