using UnityEngine;
using System.Collections;

// This script handles vine/player attachment 

public class VineController : MonoBehaviour {

    private PlayerController player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!player.swing)
            {
                player.currentVine = gameObject;
                player.swing = true;
                // Attack joint to connect player 
                HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
                joint.connectedBody = player.gameObject.GetComponent<Rigidbody2D>();
                /*
                Vector3 scale = player.transform.localScale;
                Quaternion rotation = player.transform.localRotation;
                player.transform.parent = gameObject.transform;
                player.transform.localRotation = rotation;
                player.transform.localScale = scale;
                */
            }
        }
    }
}
