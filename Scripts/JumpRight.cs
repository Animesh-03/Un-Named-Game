using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRight : MonoBehaviour
{
    public float jumpFact;
    public float jumpRightFact;
     private void OnTriggerEnter2D(Collider2D other) {
        
         if(other.tag == "Player")
         {
             Movement script = other.GetComponent<Movement>();
             script.rb.velocity = Vector2.up*script.jumpForce*jumpFact + Vector2.right*script.jumpForce*jumpRightFact;
         }
     }

    }
