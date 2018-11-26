using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour {
    public GameObject bomb;
    public GameObject explosionEffect;
    public GameObject player;
    private Vector3 playerPosition;
    private Vector3 currentPos;
    private Vector3 moveDirection;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;
    public float delay = 3f;

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
        transform.position += moveDirection * 3.0f * Time.deltaTime;;
        Debug.Log("resetting");
        if (countdown <= 0f){
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Destroy(Instantiate(explosionEffect, transform.position, transform.rotation), 1.0f);

        Destroy(gameObject);
    }

}
