using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckAssignedResourceHealthNode : ActionNode
{
	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(treeData.TargetObject == null) return State.Success;
		if(treeData.TargetObject.GetComponent<ResourceObject>().HP > 0)
			return State.Failure;
		else {
			return State.Success;
		}
	}
}







