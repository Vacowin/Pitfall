using UnityEngine;
using System.Collections;

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

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.canClimb = false;
        }
    }
}
