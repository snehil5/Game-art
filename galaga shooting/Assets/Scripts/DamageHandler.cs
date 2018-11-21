using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {
    public int health = 1;

    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;
    PlayerSpawner spwn;

    private void Start()
    {
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
    private void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");

        health--;
        if(invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
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
        //explosion.PlayExplosion();
        Destroy(gameObject);

        
    }
    
}
