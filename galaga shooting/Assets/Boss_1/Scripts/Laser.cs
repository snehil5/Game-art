using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speedoflaser;
    public float lifetime;
    public int damage;
    DamageHandler damaged;

    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, speedoflaser * Time.deltaTime, 0);
        pos -= transform.rotation * velocity;

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            damaged = other.GetComponent<DamageHandler>();
            damaged.hurt();
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }



}
