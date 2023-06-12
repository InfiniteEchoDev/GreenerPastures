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
    public float tolerance = 20.0f;


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

        if (context.agent.pathPending)
        {
            //Debug.Log(context.agent.name + " is currently moving towards " + blackboard.moveToPosition);
            return State.Running;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            return State.Failure;
        }

        AI_FOV agentSight = context.agent.GetComponent<AI_FOV>();

        if(agentSight != null && agentSight.closestTarget != null) 
        { 
            return State.Success;
        }

        float dist = Vector3.Distance(context.agent.transform.position, blackboard.moveToPosition);


        if (dist < tolerance)
            return State.Success;

        return State.Running;
        //return State.Running;
    }
}
