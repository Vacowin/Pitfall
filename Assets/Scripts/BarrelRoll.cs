using UnityEngine;
using System.Collections;

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
        if (moving)
        {
            player = FindObjectOfType<PlayerManager>();

            transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);
            rb2d.velocity = new Vector2(-moveSpeed, 0);

            if (transform.position.x < -100)
            {
                Destroy(gameObject);
            }
        }
	}

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
