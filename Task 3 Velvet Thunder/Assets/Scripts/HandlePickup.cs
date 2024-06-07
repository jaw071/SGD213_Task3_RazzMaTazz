using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePickup : MonoBehaviour, IBaseCollision
{
    public GameObject jumpPickup;
    public GameObject speedPickup;    

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = col.gameObject;
            HandleCollision(player);            
        }

    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = col.gameObject;
            HandleCollision(player);
        }
    }

    public void HandleCollision(GameObject player)
    {
        MovementComponent movementComponent = player.GetComponent<MovementComponent>();

        if (jumpPickup)
        {
            //increase the jumpforce from the movement component on player
            Debug.Log("Jump Pickup got");
            movementComponent.jumpForce = 12f;
            //make pickup disapear  
            jumpPickup.GetComponent<Renderer>().enabled = false;
            jumpPickup.GetComponent<Collider2D>().enabled = false;
            //start timer for jump boost
            StartCoroutine(JumpTimer(player));

        }
        if (speedPickup)
        {
            //increase horizontalplayeracceleration from the player movement component on player
            Debug.Log("Speed Pickup got");            
            movementComponent.horizontalPlayerAcceleration = 1200f;
            //make pickup disapear  
            speedPickup.GetComponent<Renderer>().enabled = false;
            speedPickup.GetComponent<Collider2D>().enabled = false;
            //start timer for speed boost
            StartCoroutine(SpeedTimer(player));
        }
        
    }
      
    //set up jumptimer so player returns to normal at the end
    private IEnumerator JumpTimer(GameObject player)
    {
        MovementComponent movementComponent = player.GetComponent<MovementComponent>();
        yield return new WaitForSeconds(5f);
        Debug.Log("no more jumpboost");
        movementComponent.jumpForce = 9f;
    }

    //set up speedtimer so player returns to normal at the end
    private IEnumerator SpeedTimer(GameObject player)
    {
        MovementComponent movementComponent = player.GetComponent<MovementComponent>();
        yield return new WaitForSeconds(5f);
        Debug.Log("speedboost is up");
        movementComponent.horizontalPlayerAcceleration = 500f;
    }
}
