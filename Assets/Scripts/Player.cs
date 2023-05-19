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
}
