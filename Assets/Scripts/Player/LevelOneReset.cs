using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reset"))
        {
            GameObject player = GameObject.Find("PlayerController");
            player.transform.position = new Vector3(-124.7f, 22.49f, 37.64f);
        }
    }
}
