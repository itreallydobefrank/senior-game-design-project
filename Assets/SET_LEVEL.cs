using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SET_LEVEL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CurrentLevel", 1);
    }
}
