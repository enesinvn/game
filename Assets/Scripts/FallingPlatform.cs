using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    public float shakeDuration = 0.5f;   
    public float shakeMagnitude = 0.1f;  
    public float fallDelay = 0.6f;       
    public float destroyDelay = 2f;      

    private Vector3 originalPosition;
    private bool isShaking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isShaking)
        {
            StartCoroutine(ShakeAndFall());
        }
    }

    private IEnumerator ShakeAndFall()
    {
        isShaking = true;
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float offsetX = Random.Range(-1f, 1f) * shakeMagnitude;
            float offsetY = Random.Range(-1f, 1f) * shakeMagnitude;
            transform.position = originalPosition + new Vector3(offsetX, offsetY, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
 
        transform.position = originalPosition;

        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;

        Destroy(gameObject, destroyDelay);

        isShaking = false;
    }
}
