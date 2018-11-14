using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public GameObject bulletPrefab;
    public Transform p1, p2, p3, p4, p5,p6,p7;
    public int shootinglvl;

	public float fireDelay = 0.25f;
	float cooldownTimer= 0;

    private void Start()
    {
        shootinglvl = 0;
    }

    // Update is called once per frame
    void Update() {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Audio.PlaySound("shooting");
            //Debug.Log("pew");
            cooldownTimer = fireDelay;

            if (shootinglvl == 0)
            {
                Instantiate(bulletPrefab, p2.position, p2.rotation);
                Instantiate(bulletPrefab, p3.position, p3.rotation);
            }

            if (shootinglvl == 1)
            {
                Instantiate(bulletPrefab, p1.position, p1.rotation);
                Instantiate(bulletPrefab, p2.position, p2.rotation);
                Instantiate(bulletPrefab, p3.position, p3.rotation);
            }

            if (shootinglvl == 2)
            {
                Instantiate(bulletPrefab, p1.position, p1.rotation);
                Instantiate(bulletPrefab, p2.position, p2.rotation);
                Instantiate(bulletPrefab, p3.position, p3.rotation);
                Instantiate(bulletPrefab, p4.position, p4.rotation);
                Instantiate(bulletPrefab, p5.position, p5.rotation);
            }
            if (shootinglvl >= 3)
            {
                Instantiate(bulletPrefab, p1.position, p1.rotation);
                Instantiate(bulletPrefab, p2.position, p2.rotation);
                Instantiate(bulletPrefab, p3.position, p3.rotation);
                Instantiate(bulletPrefab, p4.position, p4.rotation);
                Instantiate(bulletPrefab, p5.position, p5.rotation);
                Instantiate(bulletPrefab, p6.position, p6.rotation);
                Instantiate(bulletPrefab, p7.position, p7.rotation);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "powerup")
        {
            collectPower();
            Debug.Log(shootinglvl);
        }
    }

    void collectPower()
    {
        shootinglvl += 1;
    }
}
