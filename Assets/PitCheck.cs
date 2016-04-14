using UnityEngine;
using System.Collections;

public class PitCheck : MonoBehaviour {

    private PlayerManager player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Mathf.Abs(player.gameObject.transform.position.y - gameObject.transform.position.y) < 0.2)
            {
                player.KillPlayer();
            }
        }
    }
}
