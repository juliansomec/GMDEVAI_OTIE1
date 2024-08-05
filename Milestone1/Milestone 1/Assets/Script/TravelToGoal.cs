using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToGoal : MonoBehaviour
{
    public Transform goal;
    float speed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(goal);
        Vector3 dir = goal.position - this.transform.position;

        if (dir.magnitude > 1)
        {
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
        
    }
}
