using UnityEngine;
using System.Collections;

// This script manages the player heath/life states

public class PlayerManager : MonoBehaviour {

    public int MAX_HEATH = 1000;
    public int health;
    public int life = 3;
    public int damageTaken = 0;

    private Animator anim;
    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        health = MAX_HEATH;
        anim = GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        // reset damage
        damageTaken = 0;
    }

    void LateUpdate()
    {
        CheckDamage();
    }

    // Taking damage from touching barrels
    public void TakeDamage(int value)
    {
        damageTaken += value;
    }

    // Calculate damage inflicted by barrels
    private void CheckDamage()
    {
        anim.SetFloat("Damage", damageTaken);

        if (damageTaken > 0)
        {
            anim.Play("Damaged");
            health -= damageTaken;
        }
        if (health <= 0)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        health = 0;
        life--;
        if (life <= 0)
        {
            GameOver();
        }
        else
        {
            // Respawn player if there is still life left
            gameObject.SetActive(false);
            Invoke("Respawn", 1);
        }
    }

    // Respawn player at the current spawn spot
    private void Respawn()
    {
        damageTaken = 0;
        gameObject.SetActive(true);
        anim.Play("Idle");
        health = MAX_HEATH;
        levelManager.RespawnPlayer();
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
    }
}
