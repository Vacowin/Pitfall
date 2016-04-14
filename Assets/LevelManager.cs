using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public Transform playerSpawnSpot;
    public Transform barrelSpawnSpot;
    public float barrelSpawnTime;
    public GameObject barrel;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnBarrel", barrelSpawnTime, barrelSpawnTime);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void SpawnBarrel()
    {
        Instantiate(barrel, barrelSpawnSpot.position, barrelSpawnSpot.rotation);
    }
}
