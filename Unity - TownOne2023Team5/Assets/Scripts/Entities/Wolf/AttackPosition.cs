using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class AttackPosition : ActionNode
{
/*
    float damage = 2.0f;
    float health = 10.0f;*/

    protected override void OnStart() {

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {

        return State.Success;
    }
}