using UnityEngine;
using System.Collections;

// This script handles responsibilies of switching camera modes and controling camera position

public class CameraController : MonoBehaviour {

    LevelManager levelManager;
    public bool followPlayer;
    PlayerController player;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();
        followPlayer = false;

        // Set camera size to fit 100 units scene width
        Camera.main.orthographicSize = (float)(levelManager.SCENE_WIDTH * Screen.height / Screen.width * 0.5);
    }
	
	// Update is called once per frame
	void Update () {
        // Press 'C' to switch cameras
        if (Input.GetKeyDown(KeyCode.C))
        {
            followPlayer = !followPlayer;
            adjustCamera();
        }

        if (followPlayer)
        {
            // Manually set camera position to follow the player
            gameObject.transform.position = new Vector3(player.transform.position.x, 5, gameObject.transform.position.z);
        }
	}

    public void adjustCamera()
    {
        if (!followPlayer)
        {
            // Caculate the new camera position based on the current respawn spot
            float x = levelManager.playerSpawnSpot.position.x;
            x = ((int) (x / levelManager.SCENE_WIDTH))* levelManager.SCENE_WIDTH  + levelManager.SCENE_WIDTH/2;
            gameObject.transform.position = new Vector3(x, 5,gameObject.transform.position.z);
        }
    }
}
