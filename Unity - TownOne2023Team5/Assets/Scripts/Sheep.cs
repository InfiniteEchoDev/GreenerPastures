using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;


public class Sheep : MonoBehaviour {

	public float health = 2.0f;

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

	private bool facingRight;

	[Header( "Obj Refs" )]
	public NavMeshAgent agent;
	public Animator animator;

	private void Awake() {
		currentMoveTargetPos = transform.position;
		//SetMoveTarget( Vector3.zero );

		if( agent is null || agent.Equals(null) )
			agent = GetComponent<NavMeshAgent>();

		if (animator is null || animator.Equals(null))
			animator = GetComponentInChildren<Animator>();

		animator.SetBool("Facing Back", true);
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

		dangerousDistance = dangerDist / 2;

		damage *= damageMult;
	}

 	void Update() {
		float verticalVelocity = (IsoMgr.Instance.IsoRotation.rotation * agent.velocity).x;
		if (verticalVelocity > 0.2f) // facing up
		{
			Debug.Log("[Sheep] Facing away from camera");
			animator.SetBool("Facing Back", false);		
		} else if (verticalVelocity < 0.2f) {
			Debug.Log("[Sheep] Facing towards to camera");
			animator.SetBool("Facing Back", true);	
		}

		bool movingRight = (IsoMgr.Instance.IsoRotation.rotation * agent.velocity).z < 0;
		if (movingRight && !facingRight)
		{
			Flip();
			facingRight = true;
		} else if (!movingRight && facingRight) {
			Flip();
			facingRight = false;
		}
	}

	void Flip()
	{
		transform.Rotate(0, 180, 0);
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

	public IEnumerator PlayDeathAnimation()
	{
		animator.SetTrigger("Die");
		agent.enabled = false;
		yield return new WaitForSeconds(1.0f);
		SheepsMgr.Instance.Disable(this);
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
