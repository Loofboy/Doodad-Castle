using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireProjectileNode : ActionNode
{

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(agent.projectile == null || treeData.TargetLocation == Vector3.zero) return State.Failure;
		agent.FireProjectile(agent.Player.transform.position);
		return State.Success;
	}
}





