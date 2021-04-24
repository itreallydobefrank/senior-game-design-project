using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Level_3 : MonoBehaviour
{
    public GameObject OrangeAreaTwo;

    // Start is called before the first frame update
    void Start()
    {
        OrangeAreaTwo.SetActive(false);
        PlayerPrefs.SetInt("CurrentLevel", 3);        
    }

}
