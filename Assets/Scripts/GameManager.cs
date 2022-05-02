using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject brick;
    private Vector3 screenBounds;
    private int brickCount = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        float screenHeigt = Screen.height;
        float screenWidth = Screen.width;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(
            screenWidth, screenHeigt));
        // Debug.Log(screenBounds);
        
        // Instantiate(brick, new Vector3(0,1), Quaternion.identity);
        for (int i = 0; i < brickCount; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                // Instantiate(brick, new Vector3((-screenBounds.x + (i*(screenBounds.x/6))+(screenBounds.x/6)), screenBounds.y - j-1 ), Quaternion.identity);
                Instantiate(brick, new Vector3(i * (screenBounds.x/brickCount), screenBounds.y - j-1 ), Quaternion.identity);
                if(i != 0){
                    Instantiate(brick, new Vector3(-(i * (screenBounds.x/brickCount)), screenBounds.y - j-1 ), Quaternion.identity);
                }
            }
            
        }
    }


}
