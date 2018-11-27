using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class DamageHandler : MonoBehaviour {
    public int health = 1;
    public GameObject Explosion;
    private Animator MyAnimator;
    public GameObject droptop;


    EnemySpawnerLvl2 countEnemy;
    EnemySpawnerLvl2 countMini;

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
        GameObject enemylvl2 = GameObject.FindWithTag("spawning");
        countMini = enemylvl2.GetComponent<EnemySpawnerLvl2>();
        countEnemy = enemylvl2.GetComponent<EnemySpawnerLvl2>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.tag == "Player")
        {
            if (col.tag == "Enemy")
            {
                health = 0;
            }
        }

        if (gameObject.tag == "Enemy")
        {
            if (col.tag == "Player")
            {
                health = 0;
            }
        }
    }

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
            if (droptop != null)
            {
                Instantiate(droptop, transform.position, Quaternion.identity);
            }
            spwn.AddScore(1075);
            Audio.PlaySound("Explosion");
            Die();
        }
    }

    void Die()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
        if (sceneName == "SecondLevel")
        {
            Debug.Log(gameObject.tag + " is the game object ");
            if (gameObject.tag == "Enemy")
            {
                Debug.Log("check num");
                countEnemy.addCount();
            }
            if (gameObject.tag == "miniBoss")
            {
                countMini.addMini();
            }
        }
        Destroy(Instantiate(Explosion,transform.position, transform.rotation), 0.7f);
        //explosion.PlayExplosion();
        Destroy(gameObject);

        
    }
    
}
