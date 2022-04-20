using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float spin = 1f;
    private float currentRotation = 0;
    public float period = 0.1f;
    public float bounceScale = 0.1f;
    
    private void Update()
    {
        currentRotation += spin;
        transform.rotation = Quaternion.Euler(0, currentRotation, 0);
        transform.position = transform.position + bounceScale * Vector3.up * Mathf.Sin(currentRotation * period);
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if our object that hit this  has a player movement script on it.
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            Debug.Log("Collected Coin");
            playerMovement.coins += 1;
            Destroy(gameObject);
        }
    }
}
