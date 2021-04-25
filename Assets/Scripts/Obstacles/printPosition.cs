using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Position: " + gameObject.transform.position);
    }
}
