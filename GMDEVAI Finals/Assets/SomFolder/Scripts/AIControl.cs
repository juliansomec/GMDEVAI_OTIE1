using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;

    Vector3 wanderTarget;
    float playerSpeed = 5;
    float wanderRadius = 20;
    float wanderDis = 10;
    float wanderJitter = 1;
    
    public float detectRangeMult = 0.5f;

    public Material ghostMaterial;
    public Color ghostColor;
    public bool isFleeing = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerPos");
        agent = this.GetComponent<NavMeshAgent>();

        // Create a new instance of the material for this ghost
        Renderer renderer = GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            ghostMaterial = renderer.material; // This creates a new material instance
            ghostColor = ghostMaterial.color;  // Get the color of the new material instance
        }
    }

    protected void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    protected void Flee(Vector3 location)
    {
        Vector3 fleeDir = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeDir);
    }

    protected void Pursue()
    {
        Vector3 targetDir = target.transform.position - this.transform.position;
        float lookAhead = targetDir.magnitude / agent.speed;
        Seek(target.transform.position + target.transform.forward * lookAhead);
    }
    
    protected void Evade()
    {
        Vector3 targetDir = target.transform.position - this.transform.position;
        float lookAhead = targetDir.magnitude/(agent.speed + playerSpeed);
        Flee(target.transform.position + target.transform.forward * lookAhead);
    }

    protected void Wander()
    {
        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                    0,
                                    Random.Range(-1.0f, 1.0f) * wanderJitter);

        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDis);
        Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);

        Seek(targetWorld);
    }

    protected void Hide()
    {
        float distance = Mathf.Infinity;
        Vector3 chosenSpot = Vector3.zero;

        int hidingSpotsCount = World.Instance.GetHidingSpots().Length;
        for (int i = 0; i < hidingSpotsCount; i++)
        {
            Vector3 hideDir = World.Instance.GetHidingSpots()[i].transform.position - target.transform.position;
            Vector3 hidePos = World.Instance.GetHidingSpots()[i].transform.position + hideDir.normalized * 5;

            float spotDistance = Vector3.Distance(this.transform.position, hidePos);
            if (spotDistance < distance)
            {
                chosenSpot = hidePos;
                distance = spotDistance;
            }
        }
        
        Seek(chosenSpot);
    }

    protected void CleverHide()
    {
        float distance = Mathf.Infinity;
        Vector3 chosenSpot = Vector3.zero;
        Vector3 chosenDir = Vector3.zero;
        GameObject chosenGameObject = World.Instance.GetHidingSpots()[0];

        int hidingSpotsCount = World.Instance.GetHidingSpots().Length;
        for (int i = 0; i < hidingSpotsCount; i++)
        {
            Vector3 hideDir = World.Instance.GetHidingSpots()[i].transform.position - target.transform.position;
            Vector3 hidePos = World.Instance.GetHidingSpots()[i].transform.position + hideDir.normalized * 5;

            float spotDistance = Vector3.Distance(this.transform.position, hidePos);
            if (spotDistance < distance)
            {
                chosenSpot = hidePos;
                chosenDir = hideDir;
                chosenGameObject = World.Instance.GetHidingSpots()[i];
                distance = spotDistance;
            }
        }

        Collider hideCol = chosenGameObject.GetComponent<Collider>();
        Ray back = new Ray(chosenSpot, -chosenDir.normalized);
        RaycastHit info;
        float rayDist = 100.0f;
        hideCol.Raycast(back, out info, rayDist);
        Seek(info.point + chosenDir.normalized * 5);
    }

    protected bool CanSeeTarget()
    {
        RaycastHit raycastInfo;
        Vector3 rayToTarget = target.transform.position - this.transform.position;
        if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
        {
            return raycastInfo.transform.gameObject.tag == "Player";
        }
        return false;
    }

    private void Update()
    {
        Seek(target.transform.position);
    }
}
