using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        // check if our object that hit the death zone has a player movement script on it.
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.RespawnPlayer();
        }
    }
}
