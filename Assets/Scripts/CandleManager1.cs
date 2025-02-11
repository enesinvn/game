using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleManager1 : MonoBehaviour
{
    public GameObject candle;
    public Transform muzzle; 
    public int damageAmount = 1; 

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Hoca_0"))
        {
            Hoca_0 hoca = collision.GetComponent<Hoca_0>(); 
            if (hoca != null)
            {
                hoca.TakeDamage(damageAmount); 
            }
            Destroy(gameObject);
        }
    }

    void ShootCandle()
    {
        print("entered");
        if (candle != null) 
        {
            
            GameObject candleInstance = Instantiate(candle, muzzle.position, Quaternion.identity);
            Rigidbody2D rb = candleInstance.GetComponent<Rigidbody2D>(); 

            if (rb != null)
            {
                
                Vector2 direction = muzzle.right; 
                rb.AddForce(direction * 10f, ForceMode2D.Impulse); 
            }
            else
            {
                Debug.LogError("Candle prefab'ýnda Rigidbody2D bulunamadý!");
            }
        }
    }
}
