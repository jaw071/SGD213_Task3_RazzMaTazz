using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision  : MonoBehaviour, IBaseCollision
{

    //when object collides with player object, get reference to player and call player.die()
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
        playerController.die();
        Debug.Log("Player die");
    }
}
