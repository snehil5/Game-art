using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyBulletOff : MonoBehaviour {
    float speed;
    Vector2 _direction;
    bool isReady;
    private DamageHandler player;
    public GameObject bulletdeath;

    private void Awake()
    {
        speed = 5f;
        isReady = false;

    }
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageHandler>();
	}

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.hurt();
            Debug.Log("hit");
            Destroy(Instantiate(bulletdeath, transform.position, transform.rotation), 0.25f);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
               
            if((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
	}
}
