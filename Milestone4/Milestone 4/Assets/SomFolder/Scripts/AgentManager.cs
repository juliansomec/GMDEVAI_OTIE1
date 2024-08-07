using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    GameObject[] agents;
    public Transform player;

    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject ai in agents)
        {
            ai.GetComponent<AIControl>().agent.SetDestination(player.position);
        }
    }
}
