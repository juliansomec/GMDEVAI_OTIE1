using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent2 : AIControl
{
    public float detectionRange = 15f;

    private void Update()
    {
        float distToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distToTarget < detectionRange )
        {
            Hide();
        }
        else
        {
            Wander();
        }
    }
}
