using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public bool facingRight = true;
    public bool jumping = false;
    public float moveForce = 365f;
    public float moveSpeed;
    public float maxSpeed = 5f;
    //public float jumpForce = 1000f;
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

    public int health = 1000;
    public int life = 3;
    public int damageTaken = 0;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        originGravity = rb2d.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, 1 << LayerMask.NameToLayer("Ground"));

        /*
        if (Input.GetKeyDown("space") && (grounded || climbing))
        {
            jump = true;
        }
        */
        //handleVineSwing();
    }

    void FixedUpdate()
    {
        damageTaken = 0;
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        /*
        if (!grounded)
        {
            rb2d.velocity = new Vector2(0f, -jumpSpeed);
        }
        */

        if (Input.GetKeyDown("space") && grounded)
        {
            jumping = true;
            anim.SetTrigger("Jump");
            //rb2d.AddForce(new Vector2(0f, jumpForce));
            rb2d.velocity = new Vector2(0f, jumpSpeed);
        }


        if (Mathf.Abs(h) > 0.1 && grounded)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(h)*moveSpeed, rb2d.velocity.y);
        }
        /*
        if (h * rb2d.velocity.x < maxSpeed && grounded)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed && grounded)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }
        */

        if (((h > 0 && !facingRight) || h < 0 && facingRight))
        {
            Flip();
        }

        handleClimbing();

        handleVineSwing();
        /*
        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
        */
    }

    void LateUpdate()
    {
        CheckDamage();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void handleClimbing()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //anim.SetFloat("VSpeed", v);

        if (canClimb && !climbing && Mathf.Abs(v) > 0.1f && Mathf.Abs(h) < 0.1f)
        {
            climbing = true;
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            rb2d.gravityScale = 0f;
            rb2d.isKinematic = true;
        }
        else if (!canClimb && grounded)
        {
            
        }

        if (climbing)
        {
            if (v != 0f) {
                rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Sign(v) * maxSpeed);
            }
            else
            {
                rb2d.velocity = new Vector2(0f, 0f);
            }
            if (!canClimb)
            {
                climbing = false;
                rb2d.gravityScale = originGravity;
                rb2d.isKinematic = false;
            }
        }
        //anim.SetBool("Climb", climbing);
    }

    void handleVineSwing()
    {
        if (swing && Input.GetKeyDown("space"))
        {
            if (currentVine != null)
            {
                //currentVine.GetComponent<VineController>().detachVine();
                Destroy(currentVine.GetComponent<HingeJoint2D>());
                Invoke("ResetSwing", 1);
            }
            //rb2d.isKinematic = true;
            //Vector3 vinePos = currentVine.transform.position;
            //transform.position = new Vector3(vinePos.x, vinePos.y, transform.position.z);
        }
        else
        {
            //rb2d.isKinematic = false;
        }
    }

    private void ResetSwing()
    {
        swing = false;
    }

    public void TakeDamage(int value)
    {
        damageTaken += value;
    }

    private void CheckDamage()
    {
        anim.SetFloat("Damage", damageTaken);
        
        if (damageTaken > 0)
        {
            anim.Play("Damaged");
            health -= damageTaken;
        }
        if (health <= 0)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        life--;
        if (life <= 0)
        {
            GameOver();
        }
        else {
            Reswpawn();
        }
    }

    private void Reswpawn()
    {
        health = 100;
    }

    private void GameOver()
    {

    }
}
