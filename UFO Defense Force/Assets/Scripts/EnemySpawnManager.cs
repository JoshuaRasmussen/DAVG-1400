using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] ufoPrefabs; // Array to store UFO ships
    private float spawnRangeX = 20f;
    private float spawnPosZ = 20f;
    private float ySpawnPos = 1f;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomUFO", startDelay, spawnInterval);
    }

    void SpawnRandomUFO()
    {   
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        int ufoIndex = Random.Range(0, ufoPrefabs.Length); // Picks a random UFO from the array

        Vector3 spawnPos = new Vector3(randomX, ySpawnPos, spawnPosZ);

        Instantiate(ufoPrefabs[ufoIndex], spawnPos, ufoPrefabs[ufoIndex].transform.rotation); // Spawns an indexed UFO from the array
    }
}
