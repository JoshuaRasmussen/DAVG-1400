using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody enemyRb;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(Vector3.forward * -speed);
    }

    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.CompareTag("Death")) 
        {
            Destroy(gameObject);
        }
    }
}
