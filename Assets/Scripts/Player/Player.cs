using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    public int score;
    public bool safe = false;

    public Text hp_UI; 

    // Audio
    GameObject SoundManagerObject;
    SoundManager sound_manager;

    // Health bar
    public GameObject hud;
    healthBar hBar;
    public void Awake(){

        // Initialize sound
        SoundManagerObject = GameObject.Find("SOUND_MANAGER");
        sound_manager = SoundManagerObject.GetComponent<SoundManager>();
        Debug.Log("CurrentLevel: " + PlayerPrefs.GetInt("CurrentLevel"));
    }

    public void Start()
    {

        // Initialize hud
        hBar = hud.GetComponent<healthBar>();
        health = 100;
        score = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("cannonball"))
        {
           sound_manager.playPlayerHitSound();
           health -= 10;
           hBar.TakeDamage(10);
           hp_UI.text = health.ToString();
           Destroy(other.gameObject); 
        }
        
        if(other.gameObject.CompareTag("Reset")){
                GameObject player = GameObject.Find("PlayerController");
                if(PlayerPrefs.GetInt("CurrentLevel") == 1){
                    player.transform.position = new Vector3(-124.7f, 22.49f, 37.64f);
                }
                else if(PlayerPrefs.GetInt("CurrentLevel") == 2){
                    player.transform.position = new Vector3(-189.13f, 54.4f, 85.72f);
                }
        }
        
        if(other.gameObject.CompareTag("SafeZone"))
        {
            safe = true;
        } else {
            safe = false;
        }

        if(other.gameObject.CompareTag("CompleteZone")){
            var level_Num = PlayerPrefs.GetInt("CurrentLevel");
            if (level_Num == 1 || level_Num == 2)
            {
                SceneManager.LoadScene("LevelComplete");
            } else if (level_Num == 3)
            {
                SceneManager.LoadScene("YouWin");
            }

        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            Application.LoadLevel("MainMenu");
        }
        if (health <= 0)                            // Should always checks for low health, and go to Game Over screen if less than 0
        {
            PlayerPrefs.SetInt("CurrentLevel", 0);
            SceneManager.LoadScene("GameOver");
        }
    }
}