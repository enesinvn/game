using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cetvel : MonoBehaviour
{
    public int damageAmount = 1; // Amount of damage the cetvel does
    public float lifeTime = 1f; // How long the cetvel lasts before being destroyed

    private void Start()
    {
        // Automatically destroy the cetvel after its lifetime
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if it hits the player
        {
            PlayerHealth.instance.DealDamage(); // Deal damage to the player
            Destroy(gameObject); // Destroy the cetvel after hitting the player
        }
    }
}
