using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePickingNode : ActionNode
{

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(agent.GetComponent<NPCController>().isPicking)
		agent.GetComponent<NPCController>().isPicking = false;
		else if(!agent.GetComponent<NPCController>().isPicking)
		agent.GetComponent<NPCController>().isPicking = true;
		
		return State.Success;
	}
}




