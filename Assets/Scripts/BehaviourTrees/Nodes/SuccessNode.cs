using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SuccessNode : ActionNode
{
	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}
	protected override State OnUpdate(){
		return State.Success;
	}
}





