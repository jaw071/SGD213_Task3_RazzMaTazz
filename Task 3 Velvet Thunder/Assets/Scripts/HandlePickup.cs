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
        PlayerController playerController = player.GetComponent<PlayerController>();
        MovementComponent movementComponent = player.GetComponent<MovementComponent>();

        if (jumpPickup)
        {
            //insert double jump coding
            Debug.Log("Jump Pickup got");
            movementComponent.jumpForce = 10f;
           
        }
        if (speedPickup)
        {
            //insert double speed coding
            Debug.Log("Speed Pickup got");            
            movementComponent.horizontalPlayerAcceleration = 1200f;
        }
              
        Destroy(gameObject);
    }
    

}
