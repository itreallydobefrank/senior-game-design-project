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

    Target targetScript;

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
            string[] splitName = objectName.Split(' ');

            if(splitName[0] == "Cannon"){
                GameObject DamagedEnemy = GameObject.Find(objectName);
                cannonScript = DamagedEnemy.GetComponent<CannonShooter>();
                cannonScript.disableCannon();
                sound_manager.playCannonDisabledSound();
            }

            if (splitName[0] == "Target1")
            {
                GameObject HitTarget = GameObject.Find(objectName);
                targetScript = HitTarget.GetComponent<Target>();
                targetScript.activateTarget();
                sound_manager.playTargetHitSound();
            }

            if (splitName[0] == "Target2")
            {
                GameObject HitTarget = GameObject.Find(objectName);
                targetScript = HitTarget.GetComponent<Target>();
                targetScript.activateTarget();
                sound_manager.playTargetHitSound();
            }

            if (splitName[0] == "Target3")
            {
                GameObject HitTarget = GameObject.Find(objectName);
                targetScript = HitTarget.GetComponent<Target>();
                targetScript.activateTarget();
                sound_manager.playTargetHitSound();
            }

            if (splitName[0] == "Target4")
            {
                GameObject HitTarget = GameObject.Find(objectName);
                targetScript = HitTarget.GetComponent<Target>();
                targetScript.activateTarget();
                sound_manager.playTargetHitSound();
            }

            if (splitName[0] == "Target5")
            {
                GameObject HitTarget = GameObject.Find(objectName);
                targetScript = HitTarget.GetComponent<Target>();
                targetScript.activateTarget();
                sound_manager.playTargetHitSound();
            }

            if (splitName[0] == "Target6")
            {
                GameObject HitTarget = GameObject.Find(objectName);
                targetScript = HitTarget.GetComponent<Target>();
                targetScript.activateTarget();
                sound_manager.playTargetHitSound();
            }

            if (splitName[0] == "Target7")
            {
                GameObject HitTarget = GameObject.Find(objectName);
                targetScript = HitTarget.GetComponent<Target>();
                targetScript.activateTarget();
                sound_manager.playTargetHitSound();
            }

            if (splitName[0] == "Target8")
            {
                GameObject HitTarget = GameObject.Find(objectName);
                targetScript = HitTarget.GetComponent<Target>();
                targetScript.activateTarget();
                sound_manager.playTargetHitSound();
            }

            if (splitName[0] == "Target9")
            {
                GameObject HitTarget = GameObject.Find(objectName);
                targetScript = HitTarget.GetComponent<Target>();
                targetScript.activateTarget();
                sound_manager.playTargetHitSound();
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
