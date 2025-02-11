using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoca_0 : MonoBehaviour
{
    public int health = 4;
    public float moveSpeed = 2f; 
    public GameObject cetvelPrefab; 

    private void Start()
    {
        StartCoroutine(ShootRoutine()); 
    }

    private void Update()
    {
        Move(); 
    }

    private void Move()
    {
        
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); 
        }
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); 
            Shoot();
        }
    }

    private void Shoot()
    {
        
        GameObject cetvel = Instantiate(cetvelPrefab, transform.position, Quaternion.identity);
        cetvel.GetComponent<Rigidbody2D>().velocity = Vector2.left * 15f; 
        Destroy(cetvel, 5f); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Candle")) 
        {
            CandleManager1 candle = collision.GetComponent<CandleManager1>();
            if (candle != null)
            {
                TakeDamage(candle.damageAmount);
                Destroy(collision.gameObject); 
            }
        }
    }
}
