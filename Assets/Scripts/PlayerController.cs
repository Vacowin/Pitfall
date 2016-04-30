using UnityEngine;
using System.Collections;

// This script controls player's movements including climbing

public class PlayerController : MonoBehaviour {

    public bool facingRight = true;
    public float moveSpeed;

    public float jumpSpeed;
    public float groundCheckRadius;
    public Transform groundCheck;

    public bool swing = false;
    public GameObject currentVine;

    public GameObject currentLadder;
    public bool canClimb = false;
    public bool climbing = false;

    private float originGravity;
    public bool grounded = false;

    private Animator anim;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        // Store gravity scale for later use
        originGravity = rb2d.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player stands on ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, 1 << LayerMask.NameToLayer("Ground"));
    }

    void FixedUpdate()
    {
        // Character movement/animator code inspired by this video https://www.youtube.com/watch?v=Jp4gqdHXYhg 
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (Input.GetKeyDown("space") && grounded)
        {
            anim.SetTrigger("Jump");
            rb2d.velocity = new Vector2(0f, jumpSpeed);
        }


        if (Mathf.Abs(h) > 0.1 && grounded)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(h)*moveSpeed, rb2d.velocity.y);
        }

        if (((h > 0 && !facingRight) || h < 0 && facingRight))
        {
            Flip();
        }

        handleClimbing();

        handleVineSwing();
    }

    // Flip the character sprite
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Climbing code inspired by https://www.youtube.com/watch?v=KBSHz-ee8Sk
    // Add modifications to make climbing smoother and more like original game
    void handleClimbing()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        // Check if player can climb the ladder and prepare to climb
        if (canClimb && !climbing && Mathf.Abs(v) > 0.1f && Mathf.Abs(h) < 0.1f)
        {
            climbing = true;
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            rb2d.gravityScale = 0f;
            rb2d.isKinematic = true;
        }

        if (climbing)
        {
            if (v != 0f) {
                // Move up or down
                rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Sign(v) * moveSpeed);
            }
            else
            {
                rb2d.velocity = new Vector2(0f, 0f);
            }
            // Disable climbing and reset gravity scale
            if (!canClimb)
            {
                climbing = false;
                rb2d.gravityScale = originGravity;
                rb2d.isKinematic = false;
            }
        }
    }

    void handleVineSwing()
    {
        // Release vine swing
        if (swing && Input.GetKeyDown("space"))
        {
            if (currentVine != null)
            {
                Destroy(currentVine.GetComponent<HingeJoint2D>());
                Invoke("ResetSwing", 1);
            }
        }
    }

    private void ResetSwing()
    {
        swing = false;
    }
}
