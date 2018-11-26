using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeHealth : MonoBehaviour {
    public int health;
    public Animator eyeanim;
    public GameObject destroyeffect;
    public GameObject BOSS;
    public GameObject poppedeye;
    public int atbosshp;
    BossHealth bosshp;
    public GameObject chargingobject;

    void Start()
    {
        BOSS = GameObject.Find("Boss1");
        bosshp = BOSS.GetComponent<BossHealth>();
    }

    
    public void TakeDamage(int damage)
    {
        health -= damage;
        
    }

    void Update()
    {
        if (bosshp.health == 0)
        {
            DestroyEye();      //EYE IS DYING HERE TOO
        }
        else if (bosshp.health <= atbosshp)                                 //EYE IS POPPING HERE
        {
            Debug.Log("PRING BOSS HP" + bosshp.health);
            Instantiate(poppedeye, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(chargingobject);

        }else if (health <= 0)
        {
            DestroyEye();       //EYE IS DYING HERE
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            Debug.Log("The bullet is hurting me");
            eyeanim.SetTrigger("hurt");
        }

    }



    void DestroyEye()
    {
        Destroy(Instantiate(destroyeffect, transform.position, Quaternion.identity), 2.0f);
        Destroy(gameObject);
        Destroy(chargingobject);
    }





}
