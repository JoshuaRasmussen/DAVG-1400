using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private PlayerController playerController;
    private SpawnManager spawnManager;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("player").GetComponent<PlayerController>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        playerController.StartPlayer();
        spawnManager.StartSpawning(difficulty);
    }
}
