using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PaddleBehaviour : MonoBehaviour
{
    public float speed;

    private SpriteRenderer sr;

    private float paddleWidth;
    private Vector3 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        float screenHeigt = Screen.height;
        float screenWidth = Screen.width;

        paddleWidth = sr.size.x * transform.localScale.x * 0.5f;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(
            screenWidth, screenHeigt));
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0) *Time.deltaTime * speed);
        transform.position =
            new Vector3(Mathf.Clamp(transform.position.x, 
                    -screenBounds.x + paddleWidth, screenBounds.x - paddleWidth),
                transform.position.y);
    }

    
}
