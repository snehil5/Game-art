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
        

        if (bosshp.health <= atbosshp)
        {
            Debug.Log("PRING BOSS HP" + bosshp.health);
            Instantiate(poppedeye, transform.position, transform.rotation);
            Destroy(gameObject);

        }else if (health <= 0)
        {
            DestroyEye();
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

    void Popout()
    {
        
    }

    void DestroyEye()
    {
        Destroy(Instantiate(destroyeffect, transform.position, Quaternion.identity), 1.0f);
        Destroy(gameObject);
    }





}
