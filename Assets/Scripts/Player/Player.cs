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
        if(PlayerPrefs.GetInt("CurrentLevel") == 0){
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }
        Debug.Log(PlayerPrefs.GetInt("CurrentLevel"));
    }

    public void Start()
    {
        health = 200;
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
                GameObject player = GameObject.Find("PlayerController");
                player.transform.position = new Vector3(-189.13f, 54.4f, 85.72f);
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
            PlayerPrefs.SetInt("CurrentLevel", 2);
            SceneManager.LoadScene("GameOver");
        }
    }
}