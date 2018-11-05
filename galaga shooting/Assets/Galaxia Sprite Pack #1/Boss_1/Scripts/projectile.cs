using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    
    public float maxSpeed;
    public float lifetime;
    public int damage;
    Animator eyeanim;

    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;

        transform.position = pos;
    }


    //Collision With "ENEMY"
    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<BossHealth>().TakeDamage(damage);
            
            Debug.Log("I AM HITTING THE BOSS");
        }
        else if (other.CompareTag("Eye"))
        {
            other.GetComponent<EyeHealth>().TakeDamage(damage);
            
            Debug.Log("HITTING AN EYE");
        }
        else
        {
            Debug.Log("HITTING SOMETHING ELSE");
        }
        DestroyProjectile();
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }





}
