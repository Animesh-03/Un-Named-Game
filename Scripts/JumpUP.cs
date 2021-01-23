using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUP : MonoBehaviour
{
    public float jumpFact;
     private void OnTriggerEnter2D(Collider2D other) {
        
         if(other.tag == "Player")
         {
             Movement script = other.GetComponent<Movement>();
             script.rb.velocity = Vector2.up*script.jumpForce*jumpFact;
         }

    }
}
