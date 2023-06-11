using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using static UnityEngine.RuleTile.TilingRuleOutput;

[System.Serializable]
public class RotateToPosition : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {
        Vector3 target = new Vector3(blackboard.moveToPosition.x, 0, blackboard.moveToPosition.z);
        Vector3 current = context.agent.transform.position;

        //float angle = Mathf.Atan2(target.y - current.y, target.x - current.x) * Mathf.Rad2Deg;
        ///Quaternion targetRot = Quaternion.Euler(new Vector3(0, angle, 0));// Quaternion.LookRotation(blackboard.moveToPosition);

        target.x = target.x - current.x;
        target.y = target.y - current.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.Euler(new Vector3(0, angle, 0));

        //context.agent.transform.rotation = targetRot;
        return State.Success;
    }
}
