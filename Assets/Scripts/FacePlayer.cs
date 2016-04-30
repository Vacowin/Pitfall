using UnityEngine;
using System.Collections;

// This script makes sure the crocodile also faces to the player

public class FacePlayer : MonoBehaviour {

    public Transform playerPos;
    public bool facingLeft;

    // Use this for initialization
    void Start () {
        facingLeft = true;
	}
	
	// Update is called once per frame
	void Update () {
        // Change crocodile facing state based on player position

	    if (playerPos.position.x < gameObject.transform.position.x && !facingLeft )
        {
            facingLeft = true;
            Invoke("Flip", 0.5f);
        }
        else if (playerPos.position.x > gameObject.transform.position.x && facingLeft)
        {
            facingLeft = false;
            Invoke("Flip", 0.5f);
        }
	}

    // Flip crocodile sprite
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
