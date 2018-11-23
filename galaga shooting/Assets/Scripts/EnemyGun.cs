using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {

    public GameObject EnemyBulletfab;
    // Use this for initialization

    public float nextFire = 5.0f;
    public float currentTime = 0.0f;

    void Start () {
       Invoke("FireEnemyBullet", 2f);
	}
	
	// Update is called once per frame
	void Update () {
         FireEnemyBullet();
       
    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.FindWithTag("Player");
        currentTime += Time.deltaTime;

        if (playerShip != null)
        {
            if(currentTime > nextFire)
            {
                nextFire += currentTime;
                GameObject bullet = (GameObject)Instantiate(EnemyBulletfab);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
                nextFire -= currentTime;
                currentTime = 0.0f;
            }

            
        }
    }
}
