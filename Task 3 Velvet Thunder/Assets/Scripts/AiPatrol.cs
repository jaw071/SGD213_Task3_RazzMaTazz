using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(MovementComponent))]

public class AiPatrol : MonoBehaviour
{
    
    private MovementComponent movementComponent;
    //direction to node from gameObject position
    private Vector3 direction;
    //current node to move to
    private int index;
    // array of patrol nodes
    public GameObject[] patrolPoints;

    private void Start()
    {
        movementComponent = GetComponent<MovementComponent>();
        index = 0;



    }

    void Update()
    {
        //get direction of current node based of position of gameObject
        direction = (patrolPoints[index].transform.position - transform.position).normalized;
        //move player toward direction using movement component
        movementComponent.MovePlayer(direction);
        
    }

    //when gameobject collides with node, change current node to next in array, going back to start of array when reaching the end.
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Patrol")
        {
            index = (index + 1) % patrolPoints.Length;
        }
    }

    
}
    
    
