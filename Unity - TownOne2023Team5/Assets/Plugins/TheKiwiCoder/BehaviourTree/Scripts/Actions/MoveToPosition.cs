using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEditor;


[System.Serializable]
public class MoveToPosition : ActionNode
{
    public float speed = 5;
    public float stoppingDistance = 0.1f;
    public bool updateRotation = true;
    public float acceleration = 40.0f;


    float damage = 10.0f;
    float health = 1.0f;

    protected override void OnStart()
    {
        context.agent.stoppingDistance = stoppingDistance;
        context.agent.speed = speed;
        //context.agent.updateRotation = updateRotation;
        context.agent.acceleration = acceleration;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        context.agent.destination = blackboard.moveToPosition;

        if (context.agent.remainingDistance < blackboard.distBeforeCloseTolerance)
        {
            blackboard.sheepInRange = true;

            return State.Success;
        }
        else
        {
            blackboard.sheepInRange = false;

        }

        if (context.agent.pathPending)
        {
            //Debug.Log(context.agent.name + " is currently moving towards " + blackboard.moveToPosition);
            return State.Running;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            return State.Failure;
        }

        return State.Success;
        //return State.Running;
    }
}
