using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       PlayerPrefs.SetInt("CurrentLevel", 0); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
