using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowCollision : MonoBehaviour
{
    public Transform player;
    public float minDistance = 0.5f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= minDistance)
            {
                Debug.Log("Oyuncu tamamen gölgenin içinde! Oyun Bitti!");

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
