using UnityEngine;
using System.Collections;



public class RaycastShoot : MonoBehaviour {
	public float gunRange = 100f;
	private Camera fpsCam;
	private ParticleSystem muzzleFlash;

    // Audio
    GameObject SoundManagerObject;
    SoundManager sound_manager;

	// Deactivated Platforms waiting to be activated
	public GameObject orangeAreaOne;
	public GameObject orangeAreaTwo;	
	public GameObject blueAreaOne;
	public GameObject blueAreaTwo;
	public GameObject yellowArea;
	public GameObject redAreaOne;
	public GameObject platformTwentyFive;
	public GameObject platformTwentySix;
	public GameObject cube;

	void Start()
	{
		muzzleFlash = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();
        SoundManagerObject = GameObject.Find("SOUND_MANAGER");
        sound_manager = SoundManagerObject.GetComponent<SoundManager>();
		fpsCam = GetComponentInParent<Camera>(); // ****************** Check to see if it works ***********************88
	}


	void Update()
	{
		
		if(Input.GetButtonDown("Fire1"))
		{
			muzzleFlash.Play();	
			sound_manager.playGunShotSound();
			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, gunRange))
			{

				// Deactivating cannons
				string objectName = hit.transform.name;
				string[] splitName = objectName.Split(' ');
				if(splitName[0] == "Cannon"){
					GameObject DamagedEnemy = GameObject.Find(objectName);
					CannonShooter cannonScript = DamagedEnemy.GetComponent<CannonShooter>();
					cannonScript.disableCannon();
					sound_manager.playCannonDisabledSound();
				}


				// Shooting targets
				if(hit.transform.name == "Target1"){
					sound_manager.playTargetHitSound();
					blueAreaOne.SetActive(true);
				}

				if(hit.transform.name == "Target2"){
					sound_manager.playTargetHitSound();
					blueAreaTwo.SetActive(true);
				}

				if(hit.transform.name == "Target3"){
					sound_manager.playTargetHitSound();
					yellowArea.SetActive(true);
				}

				if(hit.transform.name == "Target4"){
					sound_manager.playTargetHitSound();
					orangeAreaOne.SetActive(true);
				}

				if(hit.transform.name == "Target6"){
					sound_manager.playTargetHitSound();
					platformTwentyFive.SetActive(true);
				}
				
				if(hit.transform.name == "Target7"){
					sound_manager.playTargetHitSound();
					platformTwentySix.SetActive(true);
				}

				if(hit.transform.name == "Target8"){
					sound_manager.playTargetHitSound();
					redAreaOne.SetActive(true);
				}
				if(hit.transform.name == "Target9"){
					sound_manager.playTargetHitSound();
					cube.SetActive(true);
				}
				if(hit.transform.name == "Target10"){
					sound_manager.playTargetHitSound();
					orangeAreaTwo.SetActive(true);
				}
			} 
		}
	}
}
