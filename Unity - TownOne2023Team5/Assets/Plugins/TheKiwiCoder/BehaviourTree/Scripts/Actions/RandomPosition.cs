using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using System.Drawing;
using UnityEngine.UIElements;

[System.Serializable]
public class RandomPosition : ActionNode 
{
    private Vector2 min = Vector2.one * -100;
    private Vector2 max = Vector2.one * 100;

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        Vector3 pos = context.agent.transform.position;

        pos.x += Random.Range(min.x, max.x);
        pos.z += Random.Range(min.y, max.y);
        blackboard.moveToPosition = pos;

        Debug.Log("<color=yellow>[BT] Position is " + pos.x + " " + pos.y + "\nRange is " + min + " and " + max + "</color>");
        return State.Success;
    }
}
