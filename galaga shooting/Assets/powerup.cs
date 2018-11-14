using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour {

    private PlayerShooting player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerShooting>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            Destroy(gameObject);
        }
    }
}
