using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ghostObject;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(ghostObject[Random.Range(0, ghostObject.Length)], spawnPoint.position, spawnPoint.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
