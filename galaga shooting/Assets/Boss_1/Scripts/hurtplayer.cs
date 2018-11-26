using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtplayer : MonoBehaviour {
    DamageHandler damaged;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damaged = collision.GetComponent<DamageHandler>();
            damaged.hurt();
        }

    }

}
