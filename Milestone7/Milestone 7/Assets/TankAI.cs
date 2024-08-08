using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{ 
    Animator anim;
    public GameObject player;

    public GameObject bullet;
    public GameObject turret;

    public GameObject GetPlayer()
    {
        return player;
    }

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }
}
