using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{

    public GameObject creditsScene;

    public void ShowCredits()
    {
        creditsScene.SetActive(true);
    }
}
