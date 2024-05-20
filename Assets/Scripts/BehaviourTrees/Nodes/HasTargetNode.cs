using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HasTargetNode : ActionNode
{
	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(treeData.assignedResource != null)
			return State.Success;
		else return State.Failure;
	}
}







