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
    public bool isOnGround = true;
    private float jumpForce = 5.0f;
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
    private SpawnManager spawnManager;

    void Awake()
    {
        Time.timeScale = 0;
        lives = 3;
        explosionParticle.Pause();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        
    }

    // Start is called before the first frame update
    public void StartPlayer()
    {
        Time.timeScale = 1;
        playerRb = GetComponent<Rigidbody>();
        isGameActive = true;
        score = 0;
        lives = 3;
        UpdateScore(0);
        UpdateLives(3);
        titleCard.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            GameOver();
        }

        if (isGameActive)
        {
            MovePlayer();
            ConstrainPlayerPosition();
        }
        
    }

    // Moves the player based on arrow key input and space bar
    void MovePlayer()
    {
        if (isGameActive)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            playerRb.AddForce(Vector3.forward * speed * vertical);
            playerRb.AddForce(Vector3.right * speed * horizontal);
            
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
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

    // controls player interactivity amongst game objects and environment
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
            Debug.Log("Player is on a platform." + isOnGround);
        }

        else if(collision.gameObject.CompareTag("Enemy"))
        {
            lives--;
            UpdateLives(lives);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Eat 1"))
        {
            Destroy(other.gameObject);
            UpdateScore(100);
        }

        if(other.gameObject.CompareTag("Eat 2"))
        {
            Destroy(other.gameObject);
            UpdateScore(50);
        }

        if (other.gameObject.CompareTag("Death"))
        {
            lives = 0;
            UpdateLives(lives);
        }
    }

    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score\n" + score;
    }

    private void UpdateLives(int lifeChange)
    {
        lifeText.text = "Life\n" + lifeChange;
    }

    public void GameOver()
    {
        isGameActive = false;

        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        dirtParticle.Stop();
        fox.SetActive(false);
        explosionParticle.Play();
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
