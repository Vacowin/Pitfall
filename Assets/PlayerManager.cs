using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public int MAX_HEATH = 1000;
    public int health;
    public int life = 3;
    public int damageTaken = 0;

    private Animator anim;

    // Use this for initialization
    void Start () {
        health = MAX_HEATH;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        damageTaken = 0;
    }

    void LateUpdate()
    {
        CheckDamage();
    }

    public void TakeDamage(int value)
    {
        damageTaken += value;
    }

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
            gameObject.SetActive(false);
            Invoke("Respawn", 1);
        }
    }

    private void Respawn()
    {
        damageTaken = 0;
        gameObject.SetActive(true);
        anim.Play("Idle");
        health = MAX_HEATH;
        gameObject.transform.position = new Vector3(0, 2, gameObject.transform.position.z);
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
    }
}
