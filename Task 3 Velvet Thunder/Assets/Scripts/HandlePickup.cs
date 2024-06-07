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
            //deactivate pickup            
            jumpPickup.SetActive(false);

        }
        if (speedPickup)
        {
            //increase horizontalplayeracceleration from the player movement component on player
            Debug.Log("Speed Pickup got");            
            movementComponent.horizontalPlayerAcceleration = 1200f;
            //deavtivate pickup
            speedPickup.SetActive(false);
        }
        
    }
        
}
