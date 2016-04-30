using UnityEngine;
using System.Collections;

// This scripts handles barrel movement
public class BarrelRoll : MonoBehaviour {

    private PlayerManager player;
    Rigidbody2D rb2d;
    public float rollSpeed;
    public float moveSpeed;
    public bool moving;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerManager>();
    }
	
	// Update is called once per frame
	void Update () {
        // Rolls across screen if set movable
        if (moving)
        {
            player = FindObjectOfType<PlayerManager>();

            transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);
            rb2d.velocity = new Vector2(-moveSpeed, 0);

            // Self destroy when gone off screen
            if (transform.position.x < -100)
            {
                Destroy(gameObject);
            }
        }
	}

    // Causes player damage on touch
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(1);
            }
        }
    }
}
