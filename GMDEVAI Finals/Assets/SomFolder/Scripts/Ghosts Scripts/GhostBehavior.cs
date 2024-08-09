using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : AIControl
{
    public Flashlight flashlight;
    public float fadeSpeed = 0.01f;
    public SphereCollider hauntZone;
    public PlayerRotate playerScript;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerPos");
        flashlight = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Flashlight>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRotate>();
        hauntZone = GetComponent<SphereCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (flashlight.IsGhostInCone() && flashlight.hit.collider.gameObject == this.gameObject)
        {
            if (!isFleeing)
            {
                isFleeing = true;
            }
        }
        else
        {
            isFleeing = false;
        }

        if (isFleeing)
        {
            Flee(target.transform.position);
            FadeOut();
        }
        else
        {
            Seek(target.transform.position);
            if (ghostColor.a < 1f)
            {
                ghostColor.a += fadeSpeed * Time.deltaTime;
                ghostColor.a = Mathf.Clamp(ghostColor.a, 0f, 1f);
                ghostMaterial.color = ghostColor;
            }
        }
    }

    void FadeOut()
    {
        ghostColor.a -= fadeSpeed * Time.deltaTime;
        ghostMaterial.color = ghostColor;

        if (ghostColor.a <= 0 )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerScript.GetDamaged();
            Debug.Log("Touched Player");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No Player Touched");
        }
    }
}
