using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2d : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius = 0.3f;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime = .35f;
    public float jumpForce = 5;
    private bool isJumping;

    private bool isGliding;
    public float walkingGravity = 3f;
    public float walkingSpeed = 5f;
    public float glidingGravity = 0.5f;
    public float glidingSpeed = 8f;
    
    private bool facingRight = true;
    private Vector3 originalLocalScale;
    private Vector3 flippedLocalScale;

    private AudioSource background; 

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<AudioSource>();
        background.Play();

        originalLocalScale = transform.localScale;
        flippedLocalScale = originalLocalScale;
        flippedLocalScale.x *= -1;
        rb = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal") ; 
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {

        //Take care of flipping the animation accordingly, if we are moving left/right and the player is currently facing right/left, then flip.
        animator.SetFloat("Speed", Mathf.Abs(moveInput * moveSpeed));
        if(moveInput > 0 && !facingRight ) {
            Flip(true);
        }
        if (moveInput < 0 && facingRight) {
            Flip(false);
        }

        JumpHandler();
    }

    void Flip(bool changeToRight) {
        facingRight = !facingRight;
        if(changeToRight) {
            transform.localScale = originalLocalScale;
        } else {
            transform.localScale = flippedLocalScale;
        }
        /*Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;*/
    }
    
    void JumpHandler() {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded && isGliding) {
            StopGliding();
        }
        if(isGrounded && !isJumping) {
            animator.SetBool("IsJumping", false);
        }

        if(isGrounded == true && Input.GetButtonDown("Jump")) {
            isJumping = true;
            animator.SetBool("IsJumping", true);
            //play jump sound here!
            
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetButton("Jump") && isJumping) {
            
            if(jumpTimeCounter > 0) {
                rb.velocity = Vector2.up * (jumpForce * 1.2f); //subsequent jump force is increased to combat accummulated force over time from gravity
                jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
                /*if(Input.GetButton("Glide")) {
                    StartGliding();
                }*/
            }

        } 
        if(!isGrounded && Input.GetButtonDown("Glide")){
            StartGliding();
        }

        if(isGliding) {
            if(Input.GetButtonUp("Glide")) {
                StopGliding();
            }
        }

        if(Input.GetButtonUp("Jump")) {
            isJumping = false;
        }
    }

    void StartGliding() {
        //stop jumping
        isJumping = false;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        isGliding = true;
        animator.SetBool("IsGliding", true);
        rb.gravityScale = glidingGravity;
        moveSpeed = glidingSpeed;
    }

    void StopGliding() {
        isGliding = false;
        animator.SetBool("IsGliding", false);
        rb.gravityScale = walkingGravity;
        moveSpeed = walkingSpeed;
    }
}
