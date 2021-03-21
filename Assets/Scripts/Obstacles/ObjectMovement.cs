using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float movementTime = 0.0f;
    private float timer = 0.0f;
    private bool movingRight = true;
    public float movementX = 1.0f;
    public float movementY = 0.0f;
    public float movementZ = 0.0f;

    private bool idle = false;
    public float stopMovementLimit = 0.0f;
    private float stopMovementTimer = 0.0f;

    void movePositive(){
        if(!idle){ 
            transform.position += new Vector3(movementX*Time.deltaTime, movementY*Time.deltaTime, movementZ*Time.deltaTime);
        }

        if(timer >= movementTime){
            movingRight = false;
            timer = 0.0f;
            idle = true;
        }

        if(stopMovementTimer >= stopMovementLimit){
            idle = false;
            stopMovementTimer = 0.0f;
        }
    }

    void moveNegative(){
        if(!idle){
            transform.position += new Vector3(-movementX*Time.deltaTime, -movementY*Time.deltaTime, -movementZ*Time.deltaTime);
        }

        if(timer >= movementTime){
            movingRight = true;
            timer = 0.0f;
            idle = true;
        }

        if(stopMovementTimer >= stopMovementLimit){
            idle = false;
            stopMovementTimer = 0.0f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(movingRight == true){
            movePositive(); 
        }

        if(movingRight == false){
            moveNegative();
        }

        if(!idle){
            timer += Time.deltaTime;
        }

        if(idle){
            stopMovementTimer += Time.deltaTime;
        }
    }
}
