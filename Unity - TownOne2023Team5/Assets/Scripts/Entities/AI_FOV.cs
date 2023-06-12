using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_FOV : MonoBehaviour
{
    [Range(0, 360)]
    public float viewAngle = 70;
    public float viewRadius = 10;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    //[HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public bool isPlayer = false;

    [NonSerialized]
    public Transform closestTarget = null;

    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .1f);
    }

    IEnumerator FindTargetsWithDelay(float delay) 
    {
        while (true) 
        {
            yield return new WaitForSeconds (delay);
            FindVisibleTargets();
        
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        closestTarget = null;

        if (targetsInViewRadius.Length <= 0)
            return;

        closestTarget = targetsInViewRadius[0].transform;

        foreach (Collider targetCollider in targetsInViewRadius)
        {
            if(isPlayer && targetCollider.gameObject.tag == "Influenced")
            {
                continue;
            }

            Transform target = targetCollider.transform;
            
            if (target == this)
                continue; 
            
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            //Target is within view angle
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) 
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);

                //No obstacles in the way. we can see the target. Add it to the visible targets.
                if (Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                    continue;
                }

                visibleTargets.Add(target);
                
                float closestTargetDist = Vector3.Distance(transform.position, closestTarget.position);

                if (distToTarget < closestTargetDist)
                    closestTarget = target;

            }
        }
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool isAngleGlobal) 
    {
        if (!isAngleGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
