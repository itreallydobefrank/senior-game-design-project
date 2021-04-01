using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BulletScript : MonoBehaviour
{
    //Destroy time
    public float destroyTime = 3.0f;
    public Camera fpsCam;
    public float range = 10000f;
    
    // Audio
    GameObject SoundManagerObject;
    SoundManager sound_manager;

    GameObject Enemies;
    CannonShooter cannonScript;
    public GameObject muzzleFlash;

    void Awake(){
        Enemies = GameObject.Find("ENEMIES");
        SoundManagerObject = GameObject.Find("SOUND_MANAGER");
        sound_manager = SoundManagerObject.GetComponent<SoundManager>();
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            string objectName = hit.transform.name;
            Debug.Log(hit.transform.name);
            string[] splitName = objectName.Split(' ');

            if(splitName[0] == "Cannon"){
                GameObject DamagedEnemy = GameObject.Find(objectName);
                cannonScript = DamagedEnemy.GetComponent<CannonShooter>();
                cannonScript.disableCannon();
                sound_manager.playCannonDisabledSound();
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            muzzleFlash.GetComponent<ParticleSystem>().Play();
            Shoot();
            sound_manager.playGunShotSound();
        }
    }
}
