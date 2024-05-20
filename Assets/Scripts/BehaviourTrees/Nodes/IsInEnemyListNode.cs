using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInEnemyListNode : ActionNode
{

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(agent.GetComponent<NPCController>().EnemyList.Contains(agent.NPC.gameObject.GetComponentInChildren<CharAnimEvents>().chardat.displayName)){
			agent.NPCenemy = true;
			return State.Success;
		}
		return State.Failure;
	}
}




