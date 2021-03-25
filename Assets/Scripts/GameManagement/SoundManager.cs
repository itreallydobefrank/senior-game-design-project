using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource gunShot;
    public AudioSource cannonShot;
    public AudioSource cannonDisabled;
    public AudioSource playerHIT;
    
    
    public void playGunShotSound(){
        gunShot.Play();
    }

    public void playCannonShotSound(){
        cannonShot.Play();
    }

    public void playCannonDisabledSound(){
        cannonDisabled.Play();
    }

    public void playPlayerHitSound(){
        playerHIT.Play();
    }

}
