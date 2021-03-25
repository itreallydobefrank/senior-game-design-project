using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public Transform player = null;
    public GameObject cannonball = null;
    public GameObject play;
    private Player the_Player;
    private float destroyTime = 3.0f;

    public float delay = 5.0f;
    private float lastFired = 0.0f;
    private bool targetSafe = false;
    public int range = 25;
    private int exitSafeZone = 0; 
    private float exitSafeZoneTimer = 0.0f;
    public float exitSafeZoneDelay = 4.0f;

    // Hit by bullet variables
    private float disabledTimer = 0.0f;
    public float disabledTimeLimit = 8.0f;
    public bool disabled = false;

    //Targeting
    public Camera cannonCam;

    // Audio
    GameObject SoundManagerObject;
    SoundManager sound_manager;

         
    public void disableCannon(){
       disabled = true; 
    }

    private bool shootDistance(){
        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        if(dist <= range){
            return true;
        } 
        return false;
    }

    void Awake(){
        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        Debug.Log(dist);
        SoundManagerObject = GameObject.Find("SOUND_MANAGER");
        sound_manager = SoundManagerObject.GetComponent<SoundManager>();
    }

    void Start(){
        play = GameObject.Find("PlayerController");
        the_Player = play.GetComponent<Player>();
    }

    private void Update()
    {
        targetSafe = the_Player.safe;

        if(disabled == true){
            disabledTimer += Time.deltaTime;
            if(disabledTimer >= disabledTimeLimit){
                disabledTimer = 0.0f; 
                disabled = false;
            }
        }
        if(targetSafe){
            exitSafeZone = 1;
        }
        if(!targetSafe && exitSafeZone == 1){
            exitSafeZone = 2;
        }
        if(exitSafeZone == 2){
            exitSafeZoneTimer += Time.deltaTime;
            if(exitSafeZoneTimer >= exitSafeZoneDelay){
                exitSafeZone = 0;
                exitSafeZoneTimer = 0.0f;
            }
        }


        TrackPlayer();
        if(!targetSafe && exitSafeZone == 0 && !disabled && shootDistance() == true){
            ShootCannon();
        }
    }

    void TrackPlayer ()
    {
        this.transform.LookAt(player);
    }

    void ShootCannon()
    {
        RaycastHit hit;
        if(Physics.Raycast(cannonCam.transform.position, cannonCam.transform.forward, out hit, range))
        {
            if (Time.time > lastFired + delay)
            {
                sound_manager.playCannonShotSound();    
                lastFired = Time.time;
                GameObject obj;
                obj = Instantiate(cannonball, this.transform.position, this.transform.rotation) as GameObject;
                obj.GetComponent<Rigidbody>().AddForce(transform.forward*10000.0f);
                Destroy(obj, destroyTime);
            }
        }
    }

}
