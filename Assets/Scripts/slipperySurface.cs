using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperySurface : MonoBehaviour
{
    public float speedMultiplier = 0.25f;
    private float originalSpeed; 
    private PlayerManagement playerMovement; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            playerMovement = collision.GetComponent<PlayerManagement>(); 
            if (playerMovement != null)
            {
                originalSpeed = playerMovement.moveSpeed;
                playerMovement.moveSpeed *= speedMultiplier;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if (playerMovement != null)
            {
                playerMovement.moveSpeed = originalSpeed; 
            }
        }
    }
}
