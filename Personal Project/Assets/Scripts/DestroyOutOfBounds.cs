using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float zDestroy = -15.0f;
    // Update is called once per frame
    void Update()
    {
        // Destroys object when it touches the lower bounds
        if(transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
        
    }
}
