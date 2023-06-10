using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Sheep : MonoBehaviour {

	[SerializeField]
	Vector3 currentMoveTargetPos = Vector3.zero;


	[Header( "Obj Refs" )]
	public NavMeshAgent agent;

	private void Awake() {
		currentMoveTargetPos = transform.position;

		if( agent is null )
			agent = GetComponent<NavMeshAgent>();

	}



	private void Update() {

	}




	public void SetMoveTarget( Vector3 moveTargetPos ) {

	}
}
