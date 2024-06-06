using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(MovementComponent))]

public class AiPatrol : MonoBehaviour, IBaseCollision
{
    
    private MovementComponent movementComponent;
    private Vector3 target;
    private Vector3 direction;
    private int index;
    public GameObject[] patrolPoints;

    private void Start()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        movementComponent = GetComponent<MovementComponent>();
        index = 0;



    }

    void Update()
    {
        direction = (patrolPoints[index].transform.position - transform.position).normalized;
        movementComponent.MovePlayer(direction);
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Patrol")
        {
            Debug.Log(index);
            index = (index + 1) % patrolPoints.Length;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Patrol")
        {
            index = (index + 1) % patrolPoints.Length;
        }
    }
}
    
    
