using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int scoreToGive;
    private int timer;
    public ParticleSystem explosion;
    public GameObject projectile;
    private bool active;
    public AudioClip explosionSound;
    private AudioSource explosionAudio;

    // Start is called before the first frame update
    void Start()
    {
        explosionAudio = GetComponent<AudioSource>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        explosion.Pause();
        active = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("UFO") && active == true)
        {
            scoreManager.IncreaseScore(scoreToGive);
            StartCoroutine(ExplosionEffect());
            explosionAudio.PlayOneShot(explosionSound, 1.0f);
            projectile.SetActive(false); //destroys this game object
            Destroy(other.gameObject); //destroys the other game object
            active = false;
        }
        
    }

    IEnumerator ExplosionEffect()
    {
        timer = 3;
        explosion.Play();
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1.0f);
        }
        Destroy(gameObject);
    }

    
}
