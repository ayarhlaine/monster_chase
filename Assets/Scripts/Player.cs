using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private Rigidbody2D playerBody;
    private Animator playerAnimator;
    private SpriteRenderer playerSR;
    private float momentX;

    private string WALK_ANIMATION = "IsWalking";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private bool isJumpPressed = false;
    private bool isGrounded;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnKeyboardMove();
        AnimatePlayer();
        OnPlayerJump();
    }

    private void FixedUpdate()
    {
        DoPlayerJump();
    }

    void OnKeyboardMove()
    {
        momentX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(momentX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        if(momentX < 0)
        {
            // moving left
            playerAnimator.SetBool(WALK_ANIMATION, true);
            playerSR.flipX = true;
        }
        else if(momentX > 0)
        {
            //moving right
            playerAnimator.SetBool(WALK_ANIMATION, true);
            playerSR.flipX = false;
        } else
        {
            // idle
            playerAnimator.SetBool(WALK_ANIMATION, false);
        }
    }

    void OnPlayerJump()
    {
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }
    }

    void DoPlayerJump()
    {
        if(isJumpPressed && isGrounded)
        {
            playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumpPressed = false;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }
}
