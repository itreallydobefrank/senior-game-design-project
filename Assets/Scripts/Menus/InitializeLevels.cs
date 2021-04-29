using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevels : MonoBehaviour
{

    public GameObject creditsScene;

    // Start is called before the first frame update
    void Start()
    {
       PlayerPrefs.SetInt("CurrentLevel", 0); 
    }

    // Update is called once per frame
    void Update()
    {
        if (creditsScene.activeSelf && Input.GetKey(KeyCode.Escape))
        {
            creditsScene.SetActive(false);
        }
    }
}
