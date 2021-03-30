using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Level_Select");
    }
}
