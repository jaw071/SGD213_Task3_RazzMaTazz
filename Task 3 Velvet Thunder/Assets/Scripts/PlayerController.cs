// A player controller component will listen for inputs from the user
// and communicate with the movement component whenever it reads any.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // local references to other scripts
    private MovementComponent movementComponent;
    private bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        movementComponent = GetComponent<MovementComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        // read the horizontal input axis
        float horizontalInput = Input.GetAxis("Horizontal");

        // if movement input is not zero
        if (horizontalInput != 0.0f)
        {
            // ensure the MovementComponent is populated to avoid errors
            if (movementComponent != null)
            {
                // pass our movement input to our MovementComponent
                movementComponent.MovePlayer(horizontalInput * Vector2.right);
            }
        }

        //handle jump input
        if (Input.GetKeyDown(KeyCode.Space) && grounded) // only if player is grounded, it passes through the jump function and grounded to false
        {
            movementComponent.Jump();
            grounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // sets the grounded variable to true if the player is on an object with the Ground tag
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
