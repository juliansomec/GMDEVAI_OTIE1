using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject turret;

    public GameObject player;

    public float fireForce = 500f;
    public float fireRate = 0.1f;
    float nextFireTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time > nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        if (rb != null )
        {
            rb.AddForce(turret.transform.forward * fireForce);

            Physics.IgnoreCollision(b.GetComponent<Collider>(), player.GetComponent<Collider>());
        }
    }
}
