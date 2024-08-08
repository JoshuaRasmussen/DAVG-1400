using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int scoreToGive;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("UFO"))
        {
            scoreManager.IncreaseScore(scoreToGive);
            Destroy(gameObject); //destroys this game object
            Destroy(other.gameObject); //destroys the other game object
        }
        
    }

    
}
