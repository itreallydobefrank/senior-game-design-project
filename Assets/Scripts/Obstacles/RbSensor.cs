using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbSensor : MonoBehaviour
{
    [HideInInspector] public CarryRB carrier;

    void OnTriggerEnter(Collider obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if(rb != null && rb != carrier._rigidbody)
        {
            carrier.Add(rb);
        }
    }

    void OnTriggerExit(Collider obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if(rb != null && rb != carrier._rigidbody)
        {
            carrier.Remove(rb);
        }
    }


}
