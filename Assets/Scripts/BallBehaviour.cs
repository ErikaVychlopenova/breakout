using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehaviour : MonoBehaviour
{
    public float speed;

    private Vector3 direction;

    private Vector3 screenBounds;

    private SpriteRenderer sr;

    private float radius;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        sr = GetComponent<SpriteRenderer>();
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight));
        radius = sr.size.x * transform.localScale.x * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x + radius > screenBounds.x ||
            transform.position.x - radius < -screenBounds.x)
        {
            direction = Vector3.Reflect(direction, Vector3.right);
        }
        if (transform.position.y + radius > screenBounds.y)
        {
            direction = Vector3.Reflect(direction, Vector3.up);
        }

        if (transform.position.y - radius < -screenBounds.y)
        {
            transform.position = new Vector3(0, 0);
        }

        if (transform.position.y  > screenBounds.y)
        {
            transform.position = new Vector3(transform.position.x, screenBounds.y - 1);
        }
        
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, direction, Color.red);
        Debug.DrawRay(Vector3.zero, screenBounds, Color.green);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Brick"))
        {
            Destroy(col.gameObject);
        }
        direction = Vector3.Reflect(direction, Vector3.up);
    }
}
