using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour {
    
    public GameObject explosionEffect;
    public GameObject player;
    private Vector3 playerPosition;
    private Vector3 currentPos;
    private Vector3 moveDirection;
    
    public float delay = 10.0f;

    bool hasExploded = false;
    float countdown;
    // Use this for initialization
    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player");
        currentPos = transform.position;
        playerPosition = player.transform.position;
        moveDirection = (playerPosition - currentPos).normalized;
        var angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position += moveDirection * 2.5f * Time.deltaTime;;
        Debug.Log("resetting");
        if (countdown <= 0f){
            Explode();
            hasExploded = true;
        }
    }

    void Explode()      //BOSS BOMB EXPLODING HERE
    {
        Destroy(Instantiate(explosionEffect, transform.position, transform.rotation), 0.47f);
        Audio.PlaySound("bombExplode");
        Destroy(gameObject);
    }

}
