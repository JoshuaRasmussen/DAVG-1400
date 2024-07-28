using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("UFO"))
        {
            Destroy(gameObject); //destroys this game object
            Destroy(other.gameObject); //destroys the other game object
        }
        
    }

    
}
