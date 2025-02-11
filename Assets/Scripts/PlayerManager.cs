using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class PlayerManagement : MonoBehaviour
{
    public float moveSpeed, candleSpeed;
    private float direction;
    private Rigidbody2D rb;
    
    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayers;
    private bool isGrounded;

    private SpriteRenderer sr;
    private Animator anim;

    private Transform muzzle;
    public Transform candle;

    public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        muzzle = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            ShootCandle();
        }

        if (!PauseMenu.instance.isPaused)
        {
            direction = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            if (rb.velocity.x < 0)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        //anim.SetBool("isGrounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.parent = null;
    }

    void ShootCandle()
    {
        Transform tempCandle = Instantiate(candle, muzzle.position, Quaternion.identity);
        tempCandle.GetComponent<Rigidbody2D>().AddForce(Vector2.right * candleSpeed * (sr.flipX ? -1 : 1), ForceMode2D.Impulse);
        Destroy(tempCandle.gameObject, 1f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); // Saðlýk 0'a ulaþtýðýnda karakterin ölmesini saðlayacak bir fonksiyon
        }
    }

    // Karakterin ölme iþlemi (isteðe baðlý)
    private void Die()
    {
        Debug.Log("Karakter öldü!");
        // Karakterin ölmesiyle ilgili diðer iþlemler (animasyon, sahneyi yeniden baþlatma vb.)
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Yatay hareket
        float moveVertical = Input.GetAxis("Vertical"); // Dikey hareket

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
