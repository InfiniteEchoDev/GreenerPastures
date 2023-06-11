using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class AttackPosition : ActionNode
{
    float damage = 10.0f;
    float health = 1.0f;

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {

        if (blackboard.sheepInRange)
        {

            AI_FOV agentSight = context.agent.GetComponent<AI_FOV>();

            if (agentSight != null && agentSight.visibleTargets.Count != 0)
            {       
                Debug.Log("[BT] OnStop sheep pos: " + blackboard.moveToPosition + " count: " + agentSight.visibleTargets[0].position);
                if (agentSight.visibleTargets[0].gameObject != null)
                {
                    agentSight.visibleTargets[0].GetComponent<Sheep>().attack(damage);
                    agentSight.visibleTargets.Remove(agentSight.visibleTargets[0]);

                }
            }
        }

        return State.Success;
    }
}
