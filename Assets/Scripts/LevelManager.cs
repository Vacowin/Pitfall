using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// This scripts contains some level's info, respawns barrels and player

public class LevelManager : MonoBehaviour {

    public int SCENE_WIDTH = 100;
    public Transform playerSpawnSpot;
    public Transform barrelSpawnSpot;
    public float barrelSpawnTime;
    public GameObject barrel;

    private PlayerManager player;
    public Text heathText;
    public Text lifeText;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerManager>();
        // Invoke SpawnBarrel method and repeat every barrelSpawnTime 
        InvokeRepeating("SpawnBarrel", barrelSpawnTime, barrelSpawnTime);
    }
	
	// Update is called once per frame
	void Update () {
        // Press 'R' to reload the level
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    // Update GUI texts
    void LateUpdate()
    {
        heathText.text = player.health.ToString();
        lifeText.text = player.life.ToString();
    }

    // Spawn barrels at the barrel spawn spot
    private void SpawnBarrel()
    {
        Instantiate(barrel, barrelSpawnSpot.position, barrelSpawnSpot.rotation);
    }

    // Set the player positon at the player respawn spot
    public void RespawnPlayer()
    {
        player.gameObject.transform.position = playerSpawnSpot.position;
    }
}
