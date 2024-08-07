using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] playerHelp;
    private float zSpawnRange = 12.0f;
    private float xSpawnRange = 14.0f;
    private float ySpawn = 1.02f;
    private float playerHelpSpawnTime = 4.0f;
    private float enemySpawnTime = 1.0f;
    private float startDelay = 1.0f;



    // Start is called before the first frame update
    public void StartSpawning(int difficulty)
    {
        enemySpawnTime /= difficulty;
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPlayerHelp", startDelay, playerHelpSpawnTime);
    }

    // Update is called once per frame

    void SpawnEnemy ()
    {

        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zSpawnRange);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        
            
    }

    void SpawnPlayerHelp ()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, playerHelp.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zSpawnRange);

        Instantiate(playerHelp[randomIndex], spawnPos, playerHelp[randomIndex].gameObject.transform.rotation);
    }
}
