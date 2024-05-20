using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FindTargetLocationNode : ActionNode
{
	GameObject ObjectContainer;
	ResourceObject[] res;
	float FurthestDist = 99999f;
	Vector3 target = Vector3.zero;
	GameObject targetobj;
	protected override void OnStart(){
		ObjectContainer = GameObject.Find("Resources");
		res = ObjectContainer.gameObject.GetComponentsInChildren<ResourceObject>();
		FurthestDist = 99999f;
		target = Vector3.zero;
	}

	protected override void OnStop(){

	}

	protected override State OnUpdate(){
		foreach(ResourceObject obj in res){
			if(!obj.gameObject.activeSelf) {}
			else if(obj.referenceResource.id == treeData.assignedResource.GetComponentInChildren<ResourceObject>().referenceResource.id && Vector3.Distance(agent.transform.position, obj.transform.position) < FurthestDist){
				FurthestDist = Vector3.Distance(agent.transform.position, obj.transform.position);
				targetobj = obj.gameObject;
				target = targetobj.transform.position;	
			}
    	}
		if(targetobj != null){
			treeData.TargetObject = targetobj;
			treeData.TargetLocation = target;
			return State.Success;
		}
		return State.Failure;
	}
}







