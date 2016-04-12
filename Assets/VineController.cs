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
        /*
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 playerPos = player.gameObject.transform.position;
            Vector3 ladderPos = gameObject.transform.position;
            if (Mathf.Abs(playerPos.x - ladderPos.x) < 0.5f)
            {
                player.canClimb = true;
                player.currentLadder = gameObject;
            }
            else
            {
                player.canClimb = false;
            }
        }
        */
        if (other.gameObject.CompareTag("Player"))
        {
            if (!player.swing)
            {
                Debug.Log("ATTACH VINE!!");
                player.currentVine = gameObject;
                player.swing = true;
                HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
                //joint.anchor = new Vector2( (-gameObject.transform.position.x)/2, 0);
                joint.connectedBody = player.gameObject.GetComponent<Rigidbody2D>();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("leave vine!!!");
            //player.swing = false;
        }
    }

    private void detachVine()
    {
        
    }

    private void  RemoveJoint()
    {
        //Destroy(GetComponent<HingeJoint2D>());
        player.swing = false;
    }
}
