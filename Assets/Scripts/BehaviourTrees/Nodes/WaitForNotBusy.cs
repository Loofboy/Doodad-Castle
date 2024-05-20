using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaitForNotBusy : ActionNode
{
	protected override void OnStart(){

	}

	protected override void OnStop(){
		
	}

	protected override State OnUpdate(){
		//child.Update();
		if(!agent.GetComponent<NPCController>().busy) return State.Success;
		return State.Running;
	}
}





