using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    public void loadLevelOne(){
        Application.LoadLevel("Level_1");
    }

    public void loadLevelTwo(){
        Application.LoadLevel("Level_2");
    }

    public void loadLevelThree(){
        Application.LoadLevel("Level_3");
    }

    public void back(){
        Application.LoadLevel("MainMenu");
    }

    public void selection(){
        Application.LoadLevel("LevelSelection");
    }
}
