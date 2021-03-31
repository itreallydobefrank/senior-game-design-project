using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BulletScript : MonoBehaviour
{
    // Bullet prefab from inspector
    public GameObject Bullet;

    // Enter the Speed of the Bullet from the Component inspector.
    public float BulletForce = 10000.0f;

    //Destroy time
    public float destroyTime = 3.0f;
    public Camera fpsCam;
    public float range = 10000f;
    
    // Audio
    GameObject SoundManagerObject;
    SoundManager sound_manager;

    GameObject Enemies;
    CannonShooter cannonScript;

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
            Shoot();
            sound_manager.playGunShotSound();
        }
    }
}
