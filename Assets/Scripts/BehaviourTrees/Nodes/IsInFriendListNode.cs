using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInFriendListNode : ActionNode
{

	protected override void OnStart(){
		
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		if(agent.GetComponent<NPCController>().FriendList.Contains(agent.NPC.gameObject.GetComponentInChildren<CharAnimEvents>().chardat.displayName)){
			agent.NPCenemy = false;
			return State.Success;
		}
		return State.Failure;
	}
}




