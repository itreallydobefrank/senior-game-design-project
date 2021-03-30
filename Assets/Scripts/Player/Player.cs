using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health;
    public int score;
    public bool safe = false;

    // Audio
    GameObject SoundManagerObject;
    SoundManager sound_manager;

    public void Awake(){
        SoundManagerObject = GameObject.Find("SOUND_MANAGER");
        sound_manager = SoundManagerObject.GetComponent<SoundManager>();
    }

    public void Start()
    {
        health = 100;
        score = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("cannonball"))
        {
           sound_manager.playPlayerHitSound();
           health -= 20;
           Destroy(other.gameObject); 
        }

        if(other.gameObject.CompareTag("Reset")){
                Debug.Log("SecondLevel");
                GameObject player = GameObject.Find("PlayerController");
                player.transform.position = new Vector3(-167.3f, 54.4f, 88.4f);
        }

        if(other.gameObject.CompareTag("SafeZone"))
        {
            safe = true;
        } else {
            safe = false;
        }

        if(other.gameObject.CompareTag("CompleteZone")){
            SceneManager.LoadScene("LevelComplete");
        }
    }

    void Update()
    {
        if (health <= 0)                            // Should always checks for low health, and go to Game Over screen if less than 0
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}