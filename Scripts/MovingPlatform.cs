using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 initPos;
    private Vector3 currentPos;
    public float posLimit;
    public float platformSpeed;
    public bool isMovingPositive;
    public bool shouldMoveHorizontal;
      void Start() 
        {
            initPos = transform.position;
            isMovingPositive = true;
        }
    
    void FixedUpdate()
    {
    
        currentPos = transform.position;
        if(shouldMoveHorizontal == true)
        {
            if (currentPos.x<(initPos.x+posLimit) && isMovingPositive == true)
            {
                transform.position= new Vector3((currentPos.x+platformSpeed),currentPos.y,currentPos.z);
            }
            else 
            {
                isMovingPositive = false;
            }
            if (currentPos.x>(initPos.x-posLimit) && isMovingPositive == false)
            {
                transform.position= new Vector3((currentPos.x-platformSpeed),currentPos.y,currentPos.z);
            }
            else
            {
                isMovingPositive = true;
            }
        }
        else
        {
            if(currentPos.y<=(initPos.y+posLimit) && isMovingPositive == true )
            {
                transform.position = new Vector3(currentPos.x,(currentPos.y+platformSpeed),currentPos.z);
            }
            else
            {
                isMovingPositive = false;
            }
            if(currentPos.y>(initPos.y-posLimit) && isMovingPositive == false )
            {
                transform.position = new Vector3(currentPos.x,(currentPos.y-platformSpeed),currentPos.z);
            }
            else
            {
                isMovingPositive = true;
            }
        }

    }

}
