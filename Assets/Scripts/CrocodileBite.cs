using UnityEngine;
using System.Collections;

// This class controls when the crocodile bites

public class CrocodileBite : MonoBehaviour {

    public float mouthTime;
    public bool mouthOpened;

    private GameObject crocodile;
    private Animator anim;

	// Use this for initialization
	void Start () {
        mouthOpened = false;

        crocodile = gameObject.transform.parent.gameObject;
        anim = crocodile.GetComponent<Animator>();

        InvokeRepeating("CheckMouth", mouthTime, mouthTime);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // Change mouth bite state 
    private void CheckMouth()
    {
        mouthOpened = !mouthOpened;
        anim.SetBool("Mouth",mouthOpened);
    }

    // Kill player on touch if mouth open
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (mouthOpened)
            {
                Debug.Log("biteee");
                other.gameObject.GetComponent<PlayerManager>().KillPlayer();
            }
        }
    }
}
