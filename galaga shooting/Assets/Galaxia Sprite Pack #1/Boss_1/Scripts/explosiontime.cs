using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiontime : MonoBehaviour {
    public GameObject explosion;
    public GameObject BOSS;
    BossHealth bosshp;
    Animator bossanim;
    float timeofexplosion = 20.0f;


    void Start()
    {
        explosion.SetActive(false);

        BOSS = GameObject.Find("Boss1");
        bosshp = BOSS.GetComponent<BossHealth>();
        bossanim = BOSS.GetComponent<Animator>();
    }

    void Update()
    {
       
        if (bosshp.health <= 0)
        {
            Debug.Log("TRIGGER???");
            bossanim.SetTrigger("death");
            timeofexplosion -= Time.deltaTime;


        }


    }

    void explode()
    {
        explosion.SetActive(true);
    }
}
