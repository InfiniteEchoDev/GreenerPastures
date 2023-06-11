using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class SetEnemyDifficultyScale : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {


        blackboard.difficultyRating = Random.Range (1.0f, 5.0f);

        float scale = blackboard.difficultyRating;

        context.agent.transform.localScale = new Vector3(scale, scale, scale);
        blackboard.distBeforeCloseTolerance *= Mathf.Pow(blackboard.difficultyRating, 2.05f);

        Vector3 currentpos = context.agent.transform.position;
        context.agent.transform.position = new Vector3(currentpos.x, 0, currentpos.z);

        return State.Success;
    }
}
