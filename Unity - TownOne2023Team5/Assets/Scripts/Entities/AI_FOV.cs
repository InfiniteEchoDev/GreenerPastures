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

    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
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

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            //Target is within view angle
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) 
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);

                //No obstacles in the way. we can see the target. Add it to the visible targets.
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask)) 
                {
                    visibleTargets.Add(target);
                }

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
