using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Flashlight : MonoBehaviour
{
    public float raycastDistance = 5f;
    public int numRays = 10;
    public float coneAngle = 30f;
    public LayerMask ghostLayer;

    public RaycastHit hit;

    public bool IsGhostInCone()
    {
        Vector3 direction = transform.forward;
        float angleStep = coneAngle / (numRays - 1);

        for (int i = 0; i < numRays; i++)
        {
            float angle = -coneAngle / 2 + i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            Vector3 rayDirection = rotation * direction;

            Ray ray = new Ray(transform.position, rayDirection);
            Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.green);

            // Perform the raycast
            if (Physics.Raycast(ray, out hit, raycastDistance, ghostLayer))
            {
                return true;
            }
        }

        return false;
    }
}
