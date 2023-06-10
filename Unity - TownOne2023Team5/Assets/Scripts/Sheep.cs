using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;


public class Sheep : MonoBehaviour {

	public enum SheepState {

	}

	[SerializeField]
	Vector3 currentMoveTargetPos = Vector3.zero;


	[Header( "Obj Refs" )]
	public NavMeshAgent agent;

	private void Awake() {
		currentMoveTargetPos = transform.position;
		//SetMoveTarget( Vector3.zero );

		if( agent is null )
			agent = GetComponent<NavMeshAgent>();

	}



	private void Update() {

	}




	public void SetMoveTarget( Vector3 moveTargetPos ) {
		currentMoveTargetPos = moveTargetPos;

		agent.destination = currentMoveTargetPos;
	
	}
}
