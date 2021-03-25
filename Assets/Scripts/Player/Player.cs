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
}