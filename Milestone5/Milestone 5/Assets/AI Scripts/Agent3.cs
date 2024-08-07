using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent3 : AIControl
{
    public float detectionRange = 15f;

    private void Update()
    {
        float distToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distToTarget < detectionRange )
        {
            Evade();
        }
        else
        {
            Wander();
        }
    }
}
