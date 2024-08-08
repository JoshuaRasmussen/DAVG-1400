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
    public bool gameActivity;

    // Starts Spawn Manager once difficulty has been selected
    public void StartSpawning(int difficulty)
    {
        enemySpawnTime /= difficulty;
        ActivityOfGame(true);
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnCollectables());
    }

    // Starts spawning enemies
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(startDelay);

        // continues to spawn Collectables untill the player dies and game activity becomes false
        while (gameActivity)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Length);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zSpawnRange);

            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
            yield return new WaitForSeconds(enemySpawnTime);
        }
        
            
    }

    // Starts spawning player Collectables
    IEnumerator SpawnCollectables ()
    {
        yield return new WaitForSeconds(startDelay);

        // continues to spawn Collectables untill the player dies and game activity becomes false
        while (gameActivity)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, playerHelp.Length);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zSpawnRange);

            Instantiate(playerHelp[randomIndex], spawnPos, playerHelp[randomIndex].gameObject.transform.rotation);
            yield return new WaitForSeconds(playerHelpSpawnTime);
        }
        
    }

    // changes whether the spawn manager should stop or start spawning enemies and collectables
    public void ActivityOfGame(bool Activity)
    {
        gameActivity = Activity;
    }
}
