using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Level_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       PlayerPrefs.SetInt("CurrentLevel", 2); 
    }
}
