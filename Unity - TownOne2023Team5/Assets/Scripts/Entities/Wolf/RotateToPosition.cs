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
        context.transform.rotation = Quaternion.LookRotation(blackboard.moveToPosition);
        return State.Success;
    }
}
