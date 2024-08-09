using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBounds = 40.0f;
    public float lowerBounds = -13.0f;
    public GameManager gameManager;
    public bool isUFO;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBounds)
        {
            
            if (isUFO)
            {
                gameManager.isGameOver = true;
                Debug.Log("Game Over!");
            }
            Destroy(gameObject);
            
        }
    }
}
