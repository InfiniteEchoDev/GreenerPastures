using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class SetEnemyDifficultyScale : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {
        blackboard.difficultyRating = Random.Range (1.0f, 5.0f);

        blackboard.damage = blackboard.difficultyRating * 2.0f;

        blackboard.health = blackboard.difficultyRating * 1.5f;

        //Debug.Log(blackboard.health + " " + blackboard.damage);

        float scale = blackboard.difficultyRating;

        context.agent.transform.localScale = new Vector3(scale, scale, scale);

        Vector3 currentpos = context.agent.transform.position;
        context.agent.transform.position = new Vector3(currentpos.x, 0, currentpos.z);

        return State.Success;
    }
}
