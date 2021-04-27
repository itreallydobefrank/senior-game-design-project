using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryRB : MonoBehaviour
{
    public bool useTriggerAsSensor = false;
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();
    public Vector3 lastPosition;
    Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
       _transform = transform;
       lastPosition = _transform.position; 

    }

    void LateUpdate()
    {
        for(int i = 0; i < rigidbodies.Count; i++){
            if(rigidbodies[i] != null){
                Rigidbody rb = rigidbodies[i];
                Vector3 velocity = (_transform.position - lastPosition);
                rb.transform.Translate(velocity, _transform);
            }
        }

        lastPosition = _transform.position;
    }

    void OnCollisionEnter(Collision c)
    {
        Rigidbody rb = c.collider.GetComponent<Rigidbody>();
        if(rb != null)
        {
            Add(rb);
        }
    }

    void OnCollisionExit(Collision c)
    {
        Rigidbody rb = c.collider.GetComponent<Rigidbody>();
        if(rb != null)
        {
            Remove(rb);
        }
    }

    public void Add(Rigidbody rb)
    {
        if(!rigidbodies.Contains(rb))
            rigidbodies.Add(rb);
    }

    public void Remove(Rigidbody rb)
    {
        if(rigidbodies.Contains(rb))
            rigidbodies.Remove(rb);
    }

}
