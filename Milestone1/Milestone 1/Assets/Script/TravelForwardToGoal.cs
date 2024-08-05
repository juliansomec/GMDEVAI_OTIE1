using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelForwardToGoal : MonoBehaviour
{
    public Transform goal;
    public float maxSpeed = 10f;
    public float minSpeed = 1f;
    public float rotSpeed = 4f;

    [SerializeField] private float currentSpeed;

    void Start()
    {
        currentSpeed = minSpeed;
    }

    void Update()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                         this.transform.position.y,
                                         goal.position.z);

        Vector3 dir = lookAtGoal - transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(dir),
                                                   Time.deltaTime * rotSpeed);

        float distanceToGoal = Vector3.Distance(lookAtGoal, transform.position);

        if (distanceToGoal > 2)
        {
            currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, distanceToGoal / 20f);
            transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        }
        else
        {
            currentSpeed = 0;
        }

    }
}
