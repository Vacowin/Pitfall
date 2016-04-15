using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    LevelManager levelManager;
    public bool followPlayer;
    PlayerController player;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();
        followPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            followPlayer = !followPlayer;
            adjustCamera();
        }

        if (followPlayer)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, 5, gameObject.transform.position.z);
        }
	}

    public void adjustCamera()
    {
        if (!followPlayer)
        {
            float x = levelManager.playerSpawnSpot.position.x;
            x = ((int) (x / levelManager.SCENE_WIDTH))* levelManager.SCENE_WIDTH  + levelManager.SCENE_WIDTH/2;
            gameObject.transform.position = new Vector3(x, 5,gameObject.transform.position.z);
        }
    }
}
