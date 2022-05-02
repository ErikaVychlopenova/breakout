using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickBehaviour : MonoBehaviour
{
    public GameObject powerUp;
    private bool isQuiting;

    private void OnApplicationQuit()
    {
        isQuiting = true;
    }

    void OnDestroy()
    {
        if (!isQuiting)
        {
            if (Random.value > 0.7)
            {
                // power up
                Instantiate(powerUp, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);

            }
        }
    }

    
}
