using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 0.5f;
    public float jumpForce = 2f;
    public bool grounded = false;
    //for now, set this to zero. Easy to imagine setting this by script
    public Vector3 respawnPoint = Vector3.zero;

    //to control animations
    public Animator playerAnimator;

    //to control physics (gravity, forces)
    public Rigidbody thisRigidbody;

    public Transform cameraTransform;


    void Start(){
        thisRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    //to be called by things that kill the player
    public void RespawnPlayer()
    {
        transform.position = respawnPoint;
    } 


    // Update is called once per frame
    void Update(){
        //shoot a ray downwards. If it hits something, raycast is true
        grounded = Physics.Raycast(transform.position, Vector3.down, 2f);

        //which direction we move. If zero, stationary
        Vector3 movementDirection = Vector3.zero;

        //input controls
        if (Input.GetKey("w"))
        {
            movementDirection += cameraTransform.forward;
        }
        if (Input.GetKey("s"))
        {
            movementDirection += -cameraTransform.forward; //back
        }
        if (Input.GetKey("a"))
        {
            movementDirection += -cameraTransform.right; //left
        }
        if (Input.GetKey("d"))
        {
            movementDirection += cameraTransform.right;
        }

        //if we are moving
        if (movementDirection.sqrMagnitude > 0)
        {
            //transform the player's position
            transform.position += movementDirection.normalized * speed;
            //tell our animator we're running
            playerAnimator.SetBool("IsRunning", true);
            //rotate towards wherever we're looking
            transform.rotation = Quaternion.LookRotation(movementDirection);
        }
        //otherwise we're standing still
        else
        {
            playerAnimator.SetBool("IsRunning", false);
        }
        //jump
        if (Input.GetKeyDown("space") && grounded)
        {
            thisRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
