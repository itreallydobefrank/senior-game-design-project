using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiButton : MonoBehaviour
{
    public Text YouWinOrLevelCompleted;
    public Button multi;
    public Button menu;

    void Awake(){
        Cursor.lockState = CursorLockMode.None;
        Button multiBtn = multi.GetComponent<Button>();
        Button menuBtn = menu.GetComponent<Button>();
        menuBtn.onClick.AddListener(mainMenu);
        multiBtn.onClick.AddListener(TaskOnClick);
        if(PlayerPrefs.GetInt("CurrentLevel") == 1 || PlayerPrefs.GetInt("CurrentLevel") == 2){
            YouWinOrLevelCompleted.text = "Level Completed";
            GameObject.Find("StateButton").GetComponentInChildren<Text>().text = "Next Level";
        } else if(PlayerPrefs.GetInt("CurrentLevel") == 3){
            YouWinOrLevelCompleted.text = "You Win!";
            GameObject.Find("StateButton").GetComponentInChildren<Text>().text = "Quit Game";
        } 
    }

    void TaskOnClick(){
        if(PlayerPrefs.GetInt("CurrentLevel") == 1){
            PlayerPrefs.SetInt("CurrentLevel", 2);
            SceneManager.LoadScene("Level_2");
        } else if(PlayerPrefs.GetInt("CurrentLevel") == 2){
            PlayerPrefs.SetInt("CurrentLevel", 3);
            SceneManager.LoadScene("Level_3");
        } else if(PlayerPrefs.GetInt("CurrentLevel") == 3){
            PlayerPrefs.SetInt("CurrentLevel", 0);
            Application.Quit();
        }
    }

    void mainMenu(){
        PlayerPrefs.SetInt("CurrentLevel", 0);
        SceneManager.LoadScene("MainMenu");
    }
}
