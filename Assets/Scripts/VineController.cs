using UnityEngine;
using System.Collections;

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
                Debug.Log("ATTACH VINE!!");
                player.currentVine = gameObject;
                player.swing = true;
                HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
                joint.connectedBody = player.gameObject.GetComponent<Rigidbody2D>();
            }
        }
    }

    private void  RemoveJoint()
    {
        //Destroy(GetComponent<HingeJoint2D>());
        player.swing = false;
    }
}
