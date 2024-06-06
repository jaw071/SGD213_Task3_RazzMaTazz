// Movement for both the player and patrolling enemy game objects will
// be provided by a movement component that interacts with the
// rigidBody2D component of the objects.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] public float horizontalPlayerAcceleration = 400f;
    [SerializeField] public float jumpForce = 5f;

    // local references
    private Rigidbody2D ourRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // populate ourRigidbody
        ourRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(float horizontalInput)
    {
        // a horizontalInput of 0 has no effect, as we want our ship to drift
        if (horizontalInput != 0) {
            //calculate our force to add
            Vector2 forceToAdd = Vector2.right * horizontalInput * horizontalPlayerAcceleration * Time.deltaTime;
            // apply forceToAdd to ourRigidbody
            ourRigidbody.AddForce(forceToAdd);
        }
    }

    public void MovePlayer(Vector2 direction)
    {
        // a horizontalInput of 0 has no effect, as we want our ship to drift
        if (direction.magnitude != 0)
        {
            //calculate our force to add
            Vector2 forceToAdd = direction * horizontalPlayerAcceleration * Time.deltaTime;
            // apply forceToAdd to ourRigidbody
            ourRigidbody.AddForce(forceToAdd);
        }
    }

    public void Jump() //handles jumping physics
    {
        //ourRigidbody.velocity = Vector2.zero; //this forces the players velocity to stop before the jump
        //ourRigidbody.velocity = new Vector2(ourRigidbody.velocity.x, jumpForce); // another option for jumping (i dont see any difference)
        ourRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}


