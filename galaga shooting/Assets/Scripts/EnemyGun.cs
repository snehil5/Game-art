using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
    
    public float startshooting;
    private float shootTime;
    public GameObject EnemyBulletfab;
	// Use this for initialization
	void Start () {
       Invoke("FireEnemyBullet", 2f);
	}
	
	// Update is called once per frame
	void Update () {

        shootTime -= Time.deltaTime;

        if (shootTime <= 0)
        {
            shootTime = startshooting;
            FireEnemyBullet();

        } else
        {

        }
       
    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.FindWithTag("Player");

        if(playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletfab);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
