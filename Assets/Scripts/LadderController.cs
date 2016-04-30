using UnityEngine;
using System.Collections;

// This script check if the player is inside the climbing area of ladder

public class LadderController : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 playerPos = player.gameObject.transform.position;
            Vector3 ladderPos = gameObject.transform.position;
            // Make sure the player stays inside climbing area
            if (Mathf.Abs(playerPos.x - ladderPos.x) < 5f)
            {
                player.canClimb = true;
                player.currentLadder = gameObject;
            }
            else
            {
                player.canClimb = false;
            }
        }
    }

    // Player leaves the ladder
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.canClimb = false;
        }
    }
}
