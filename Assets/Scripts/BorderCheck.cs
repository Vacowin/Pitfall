using UnityEngine;
using System.Collections;

// This script determines the new respawn spot after the player touch the border of the screen

public class BorderCheck : MonoBehaviour {

    private LevelManager levelManager;
    private CameraController camController;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        camController = FindObjectOfType<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Calculate new respawn spot after the player enters the screen
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            levelManager.playerSpawnSpot.position = new Vector2(transform.position.x + (player.facingRight ? 1 : -1) * 5, 5);
            // Set camera to new screen if applicable
            camController.adjustCamera();
        }
    }
}
