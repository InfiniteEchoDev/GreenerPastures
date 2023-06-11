using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class AttackPosition : ActionNode
{

    protected override void OnStart() {
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

                float returningFire = agentSight.closestTarget.GetComponent<Sheep>().attemptAttack(blackboard.damage);

                if (returningFire == 0)
                    agentSight.visibleTargets.Remove(agentSight.closestTarget.GetComponent<Transform>());
                else
                { 
                    blackboard.health -= returningFire;
                    
                    if(blackboard.health < 0)
                        context.agent.gameObject.SetActive(false);
                }
            }
        }

        return State.Success;
    }
}