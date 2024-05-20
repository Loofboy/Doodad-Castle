using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBoxTargetLocationNode : ActionNode
{
	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		
		treeData.TargetLocation = GameObject.Find("DepositBox").transform.position;
		return State.Success;
	}
}




