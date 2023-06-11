using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class AttackPosition : ActionNode
{

    float damage = 2.0f;
    float health = 10.0f;

    protected override void OnStart() {

        damage = blackboard.difficultyRating * 2.0f;

        health = blackboard.difficultyRating * 1.5f;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {

        if (blackboard.sheepInRange)
        {

            AI_FOV agentSight = context.agent.GetComponent<AI_FOV>();

            if (agentSight != null && agentSight.closestTarget != null)
            {
                //Debug.Log("[BT] Attack sheep pos: " + blackboard.moveToPosition + " count: " + agentSight.visibleTargets[0].position);

                float returningFire = agentSight.closestTarget.GetComponent<Sheep>().attemptAttack(damage);

                if (returningFire == 0)
                    agentSight.visibleTargets.Remove(agentSight.closestTarget.GetComponent<Transform>());
                else
                { 
                    health -= returningFire;
                    
                    if(health < 0)
                        context.agent.gameObject.SetActive(false);
                }
            }
        }

        return State.Success;
    }
}