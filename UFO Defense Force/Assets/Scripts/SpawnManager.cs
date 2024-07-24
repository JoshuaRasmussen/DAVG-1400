using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Pickup;
    public float xSpawnRange = 16.0f;
    public float ySpawn = 1.5f;
    public float zSpawn = 12.0f;
    public float startDelay = 1.0f;
    public float PickupSpawnTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPickup", startDelay, PickupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPickup ()
    {
        float randomX = Random.Range(-xSpawnRange,xSpawnRange);
        
        Vector3 spawnPos = new Vector3(randomX, ySpawn, zSpawn);

        Instantiate(Pickup, spawnPos, Pickup.gameObject.transform.rotation);
    }
}
