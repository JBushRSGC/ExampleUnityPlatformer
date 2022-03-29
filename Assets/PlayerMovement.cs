using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 0.5f;
    public float jumpForce = 2f;
    public bool grounded = false;
    public Vector3 respawnPoint = Vector3.zero;


    public Rigidbody rigidbody;


    void Start(){
        rigidbody = GetComponent<Rigidbody>();    
    }

    public void RespawnPlayer()
    {
        transform.position = respawnPoint;
    } 


    // Update is called once per frame
    void Update(){

        grounded = Physics.Raycast(transform.position, Vector3.down, 1.0f);

        if (Input.GetKey("w"))
        {
            transform.position += Vector3.forward * speed;
        }
        if (Input.GetKey("s"))
        {
            transform.position += Vector3.back * speed;
        }
        if (Input.GetKey("a"))
        {
            transform.position += Vector3.left * speed;
        }
        if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * speed;
        }
        if (Input.GetKeyDown("space") && grounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
