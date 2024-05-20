using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInteractAnim : ActionNode
{

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(agent.NPC == null) return State.Failure;
		agent.InteractWithNPC();
		agent.NPC.busy = true;
		agent.GetComponent<NPCController>().busy = true;
		return State.Success;
	}
}




