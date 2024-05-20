using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeRunner : MonoBehaviour
{
	public BehaviourTree tree;

	void Start()
	{
		tree = tree.Clone();
		tree.Bind(GetComponent<AiAgent>());
	}

	void Update()
	{
		tree.Update();
	}

	public void Restart()
    {
		tree = tree.Clone();
		tree.Bind(GetComponent<AiAgent>());
	}
}



