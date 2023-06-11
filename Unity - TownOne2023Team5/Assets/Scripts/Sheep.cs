using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;


public class Sheep : MonoBehaviour {

	public float health = 5.0f;

	public float damage = 1.0f;
	public float damageMult = 1.0f;

    [NonSerialized]
    public float dangerousDistance = 10.0f;

	[NonSerialized]
	public Transform playerPosition = null;

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

	public void updateSheepHordeDamage(float numOfSheep, float dangerDist) 
	{
		if (numOfSheep == 0)
		{ 
			damageMult = 1.0f;
			damage = 0.0f;
			return;
        }

        damageMult = (numOfSheep * .25f) + 1.0f;

		dangerousDistance = dangerDist;

		damage *= damageMult;
	}

	private void Update() {

	}

	public float attemptAttack(float dmg) 
	{
		float distanceFromShepard = dangerousDistance + 1.0f;

		if (playerPosition != null)
			distanceFromShepard = Vector3.Distance(this.transform.position, playerPosition.position);

		if (distanceFromShepard > dangerousDistance)
			damage = 1.0f;

		if(dmg > damage)
		{ 
			health -= dmg;
            SheepsMgr.Instance.CheckSheeps(this);

			return 0.0f;
        }

		return damage;	
	}

    public void SetMoveTarget(Vector3 moveTargetPos)
    {
        currentMoveTargetPos = moveTargetPos;

        agent.destination = currentMoveTargetPos;

        //Debug.Log("[" + this.gameObject.name + "] " + agent.destination);
    }

    public void SetRunFromPos( Vector3 runFromPos ) {
		Debug.LogError("[Sheep] This should not be occuring at this moment. ");

		currentMoveTargetPos = ( ( transform.position - runFromPos ).normalized * SheepsMgr.Instance.RunFromDist ) + transform.position;

		agent.destination = currentMoveTargetPos;
	}
}
