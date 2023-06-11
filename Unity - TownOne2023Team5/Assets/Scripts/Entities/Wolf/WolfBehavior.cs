using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class WolfBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        AI_FOV agentSight = this.GetComponent<AI_FOV>();
        BehaviourTree bt = this.GetComponent<BehaviourTreeRunner>().tree;

        if (agentSight != null && agentSight.closestTarget != null)
        {
            //Debug.Log("[BT] Attack sheep pos: " + blackboard.moveToPosition + " count: " + agentSight.visibleTargets[0].position);

            float returningFire = agentSight.closestTarget.GetComponent<Sheep>().attemptAttack(bt.blackboard.damage);

            if (returningFire == 0)
                agentSight.visibleTargets.Remove(agentSight.closestTarget.GetComponent<Transform>());
            else
            {
                bt.blackboard.health -= returningFire;

                if (bt.blackboard.health < 0)
                    this.gameObject.SetActive(false);
            }
        }
    }

}
