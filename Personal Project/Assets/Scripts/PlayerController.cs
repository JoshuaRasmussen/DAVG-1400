using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    private float speed = 10.0f;
    private Rigidbody playerRb;
    private float zBound = 9;
    private int score;
    private int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public bool isGameActive;
    public GameObject titleCard;
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    public GameObject fox;
    public SpawnManager spawnManager;

    // starts all of the essential things to the gameplay when first booting up the game
    void Awake()
    {
        Time.timeScale = 0;
        lives = 3;
        explosionParticle.Pause();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Allows player to start moving once difficulty is selected and starts everything that is essential for the game
    public void StartPlayer()
    {
        Time.timeScale = 1;
        playerRb = GetComponent<Rigidbody>();
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        UpdateLives(3);
        titleCard.gameObject.SetActive(false);
        StartCoroutine(StartPointTimer());
        
    }

    // Update is called once per frame
    void Update()
    {
        // activates game over upon reaching zero health
        if (lives <= 0)
        {
            GameOver();
        }

        // allows player movement only when isGameActive is true
        if (isGameActive)
        {
            MovePlayer();
            ConstrainPlayerPosition();
        }
        
    }

    // Moves the player based on arrow/WASD key input and space bar
    void MovePlayer()
    {
        if (isGameActive)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            playerRb.AddForce(Vector3.forward * speed * vertical);
            playerRb.AddForce(Vector3.right * speed * horizontal);
        }
    }

    // prevents player from going off the top of the screen
    void ConstrainPlayerPosition()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
    }

    // controls player interactivity amongst game objects
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            lives--;
            UpdateLives(lives);
        }

    }

    // controls player triggers
    private void OnTriggerEnter(Collider other)
    {
        // Allows player to collect/eat the chick
        if(other.gameObject.CompareTag("Eat 1"))
        {
            Destroy(other.gameObject);
            UpdateScore(100);
        }

        // Allows player to collect/eat the Rooster
        if(other.gameObject.CompareTag("Eat 2"))
        {
            Destroy(other.gameObject);
            UpdateScore(50);
        }

        // kills player when triggering interactions with the Hen Mob
        if (other.gameObject.CompareTag("Death"))
        {
            lives = 0;
            UpdateLives(lives);
        }
    }

    // updates player's score
    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score\n" + score;
    }

    // updates player's lives
    private void UpdateLives(int lifeChange)
    {
        int life = lifeChange;

        // keeps player lives from going below zero
        if (lifeChange < 0)
        {
            life = 0;
        }

        lifeText.text = "Life\n" + life;
    }

    // stops Enemy and Collectable spawning when player dies and brings up restart menu to restart game
    public void GameOver()
    {
        isGameActive = false;

        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        dirtParticle.Stop();
        fox.SetActive(false);
        explosionParticle.Play();
        spawnManager.ActivityOfGame(false);
    }

    // Restarts the game when restart button has been pressed
    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // gives points to the player over time
    public IEnumerator StartPointTimer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1.0f);

            // makes sure that points are not given after player dies
            if (isGameActive)
            {
                UpdateScore(10);
            }
            
        }
    }
}
