using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeHealth : MonoBehaviour {
    public int health;
    public Animator eyeanim;
    public GameObject destroyeffect;

    public void TakeDamage(int damage)
    {
        health -= damage;
        
    }

    void Update()
    {
        if (health <= 0)
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

    void DestroyEye()
    {
        Destroy(Instantiate(destroyeffect, transform.position, Quaternion.identity), 1.0f);
        Destroy(gameObject);
    }




}
