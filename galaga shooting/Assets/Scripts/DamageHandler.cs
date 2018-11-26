using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {
    public int health = 1;
    public GameObject Explosion;
    private Animator MyAnimator;
    public GameObject droptop;


    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;
    PlayerSpawner spwn;

    private void Start()
    {
        MyAnimator = GetComponent<Animator>();
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
    /*private void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");

        health--;
        if(invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }
    }*/

    public void hurt()
    {
        Debug.Log("Trigger!");

        health--;
        StartCoroutine(HurtBlinker(0.25f));
        if (invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }
    }

    IEnumerator HurtBlinker(float hurtTime)
    {


        MyAnimator.SetLayerWeight(1, 1f);

        yield return new WaitForSeconds(hurtTime);



        MyAnimator.SetLayerWeight(1, 0f);
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
            Instantiate(droptop, transform.position, Quaternion.identity);
            spwn.AddScore(5);
            Die();
        }
    }

    void Die()
    {
        Destroy(Instantiate(Explosion,transform.position, transform.rotation), 0.7f);
        //explosion.PlayExplosion();
        Destroy(gameObject);

        
    }
    
}
