using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpInvNode : ActionNode
{

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		agent.GetComponent<NPCController>().DumpItems();
		agent.GetComponent<NPCController>().busy = false;
		return State.Success;
	}
}




