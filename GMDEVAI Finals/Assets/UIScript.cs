using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public TMP_Text scoreText;
    private float distScore = 0f;
    public float scoreIncremented = 1f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distScore += Time.deltaTime * scoreIncremented;

        scoreText.text = Mathf.FloorToInt(distScore).ToString() + "m";
    }
}
