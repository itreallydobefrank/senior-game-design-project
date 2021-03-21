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

    AudioSource myaudio;

    // Start is called before the first frame update
    void Start()
    {
        myaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //Create a bullet instance and add force to add motion
            GameObject bullet;
            bullet = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 3000.0f);

            //fix scale
            bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            //Play Audio
            myaudio.Play();

            //Destroy it after a certain time
            Destroy(bullet, destroyTime);
        }
    }
}
