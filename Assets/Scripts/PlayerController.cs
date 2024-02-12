using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public GameObject bigBulletPrefab;
    public float groundCheckDistance = 10f; // Distance to check for ground
    public LayerMask groundLayer;
    public float jumpHeight = 10f;
    private Rigidbody2D rb;
    private bool betterWeapon;
    public float bulletSpeed = 10;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    bool facingRight = true;

    public Animator animate;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        betterWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shooting();
            animate.SetTrigger("Shooting");
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
        animate.SetFloat("speed", Mathf.Abs(horizontalInput));
        spriteRenderer.flipX = movement.x < 0f;

        if(horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if(horizontalInput < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            animate.SetTrigger("Jumping");
        }


    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    void Shooting()
    {
        if (betterWeapon == false)
        {
            float direction = Mathf.Sign(transform.localScale.x);
            Vector3 spawnPosition = transform.position + new Vector3(direction, 0f, 0f);
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(direction * bulletSpeed, 0f);
        }
        else if(betterWeapon == true)
        {
            float direction = Mathf.Sign(transform.localScale.x);
            Vector3 spawnPosition = transform.position + new Vector3(direction, 0f, 0f);
            GameObject bullet = Instantiate(bigBulletPrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(direction * bulletSpeed, 0f);


        }


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Powerup"))
        {
            Destroy(collision.gameObject);
            betterWeapon = true;
            audioManager.PlaySFX(audioManager.pickUpShotgun);
        }
    }
}
