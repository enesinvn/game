using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowManager : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    public float speed = 2.0f;                 

    public Transform player;      
    public float minDistance = 0.5f;

    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Debug.Log("Oyuncu yakalandý!");

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float distance = Vector2.Distance(transform.position, player.position);
        }
    }
}
