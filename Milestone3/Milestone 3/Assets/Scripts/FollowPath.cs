using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    float speed = 5;
    float accuracy = 1;
    float rotSpeed = 2;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWaypointIndex = 0;
    Graph graph;

    private void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    private void LateUpdate()
    {
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength())
        {
            return;
        }

        currentNode = graph.getPathPoint(currentWaypointIndex);

        if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position,
                             transform.position) < accuracy)
        {
            currentWaypointIndex++;
        }

        if(currentWaypointIndex < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWaypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                       Quaternion.LookRotation(direction),
                                                       Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    public void GoToTwinMts()
    {
        graph.AStar(currentNode, wps[1]);
        currentWaypointIndex = 0;
    }

    public void GoToBarracks()
    {
        graph.AStar(currentNode, wps[2]);
        currentWaypointIndex = 0;
    }

    public void GoToCmdCenter()
    {
        graph.AStar(currentNode, wps[3]);
        currentWaypointIndex = 0;
    }

    public void GoToOilRef()
    {
        graph.AStar(currentNode, wps[5]);
        currentWaypointIndex = 0;
    }

    public void GoToTankers()
    {
        graph.AStar(currentNode, wps[6]);
        currentWaypointIndex = 0;
    }

    public void GoToRadar()
    {
        graph.AStar(currentNode, wps[9]);
        currentWaypointIndex = 0;
    }

    public void GoToCmdPost()
    {
        graph.AStar(currentNode, wps[10]);
        currentWaypointIndex = 0;
    }

    public void GoToMiddle()
    {
        graph.AStar(currentNode, wps[4]);
        currentWaypointIndex = 0;
    }
}
