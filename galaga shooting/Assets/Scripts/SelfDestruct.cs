using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    public float timer = 5f;
    public GameObject deathFX;
    private DamageHandler dam;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            dam = collision.GetComponent<DamageHandler>();
            dam.hurt();
            Destroy(Instantiate(deathFX, transform.position, transform.rotation), .2f);
            Destroy(gameObject);
        }
    }
}