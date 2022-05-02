using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpOrDownBehaviour : MonoBehaviour
{
    public GameObject powerUp;
    // public GameObject paddle;
    private Vector3 screenBounds;

    private GameObject paddle;

    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        float screenHeigt = Screen.height;
        float screenWidth = Screen.width;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(
            screenWidth, screenHeigt));
        paddle = GameObject.FindWithTag("Paddle");
        ball = GameObject.FindWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUp.transform.position.y < -screenBounds.y)
        {
            Destroy(powerUp);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Paddle"))
        {
            Destroy(powerUp);
            double randomNumber = Random.value;
            if (randomNumber > 0 &&  randomNumber <= 0.40)
            {
                
                paddle.GetComponent<PaddleBehaviour>().speed += 5f;

            }
            if (randomNumber > 0.40 && randomNumber <= 0.90)
            {
                ball.GetComponent<BallBehaviour>().speed += 2f;

            }
            else if(randomNumber > 0.90)
            {
                Instantiate(ball, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            }
        }
    }
}
