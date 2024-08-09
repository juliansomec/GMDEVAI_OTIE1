using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public Camera topDownCamera;
    private Transform flashlight;
    public float mouseSens = 2.0f;


    private void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSens;
        transform.Rotate(0, mouseX, 0);

        flashlight.rotation = transform.rotation;
    }
}
