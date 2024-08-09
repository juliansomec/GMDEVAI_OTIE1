using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRotate : MonoBehaviour
{
    public float rotationSpeed = 5.0f; // Speed of rotation
    public Transform playerBody; // Reference to the player's body

    private float mouseX;
    public int maxPlayerHealth = 10;
    public int currentHealth;

    public CourageScript courage;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
                                                                                                        
        currentHealth = maxPlayerHealth;
        courage.SetMaxHealth(currentHealth);
    }

    void Update()
    {
        // Get the horizontal mouse movement
        mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

        // Rotate the player around the Y-axis based on mouse movement
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void GetDamaged()
    {
        currentHealth--;
        courage.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
