using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        InvokeRepeating("SpawnBarrel", barrelSpawnTime, barrelSpawnTime);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    void LateUpdate()
    {
        heathText.text = player.health.ToString();
        lifeText.text = player.life.ToString();
    }

    private void SpawnBarrel()
    {
        Instantiate(barrel, barrelSpawnSpot.position, barrelSpawnSpot.rotation);
    }

    public void RespawnPlayer()
    {
        player.gameObject.transform.position = playerSpawnSpot.position;
    }
}
