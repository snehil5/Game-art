using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    private Animator MyAnimator; 
    public int health = 1;
    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;
    PlayerSpawner spwn;

    private void Start()
    {
        MyAnimator = gameObject.GetComponent<Animator>();
        correctLayer = gameObject.layer;
        GameObject spwnObject = GameObject.FindWithTag("Respawn");
        if(spwnObject != null)
        {
            spwn = spwnObject.GetComponent<PlayerSpawner>();
        }
        if(spwn == null)
        {
            Debug.Log("cannot find PlayerSpawner.");
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" || col.tag == "bullet")
        {
            Debug.Log("Crash!");

            health--;
            StartCoroutine(HurtBlinker(.2f));
            if (invulnPeriod > 0)
            {
                invulnTimer = invulnPeriod;
                gameObject.layer = 10;
            }
        }
        
    }

    void Update()
    {
        if(invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;
            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;
            }
        }
        
        if (health <= 0)
        {
           spwn.AddScore(5);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        
    }

    IEnumerator HurtBlinker(float hurtTime)
    {


        MyAnimator.SetLayerWeight(1, 1f);

        yield return new WaitForSeconds(hurtTime);



        MyAnimator.SetLayerWeight(1, 0f);
    }

}
