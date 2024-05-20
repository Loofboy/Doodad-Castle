using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaitForChildNode : DecoratorNode
{
	protected override void OnStart(){

	}

	protected override void OnStop(){
		
	}

	protected override State OnUpdate(){
		//child.Update();
		switch(child.Update()){
			case State.Running:
				return State.Running;
			case State.Failure:
				return State.Running;
			case State.Success:
				return State.Success;
		}
		return State.Running;
	}
}





