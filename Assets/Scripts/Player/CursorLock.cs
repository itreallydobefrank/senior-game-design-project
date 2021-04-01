using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{

    void Awake(){
        PlayerPrefs.SetInt("CurrentLevel", 0);
        Cursor.lockState = CursorLockMode.None;
    }
}
