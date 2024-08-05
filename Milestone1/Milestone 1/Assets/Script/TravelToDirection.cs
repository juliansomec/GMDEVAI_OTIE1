using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToDirection : MonoBehaviour
{
    
    public Vector3 dir = new Vector3(8, 0, -4);
    public float moveSpeed = 5;
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
    }
}
