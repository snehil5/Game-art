using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting2 : MonoBehaviour
{

    public int powerTime;
    private int powerTimer = 0;
    private Count Timer;

    public GameObject bulletPrefab;
    public Transform p1, p2, p3, p4, p5, p6, p7;
    public int shootinglvl;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    private void Start()
    {
        Timer = gameObject.GetComponent<Count>();
        StartCoroutine(StartCountdown(powerTime));
        shootinglvl = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        //Debug.Log("Timer is at " + Timer.powerTimer);


        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Audio.PlaySound("shooting");

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
            resetTimer();
            //StartCoroutine(Timer.StartCountdown(powerTime));
            Debug.Log(shootinglvl);
            Debug.Log(powerTimer);

        }
    }

    void collectPower()
    {
        shootinglvl += 1;
        //powerTimer = powerTime;

    }

    void resetTimer()
    {
        powerTimer += powerTime;
        if (powerTimer > powerTime)
            powerTimer = powerTime;

    }


    public IEnumerator StartCountdown(int powerTime)
    {

        while (powerTimer > -1)
        {

            Debug.Log("Countdown: " + powerTimer);
            yield return new WaitForSeconds(1.0f);
            if (powerTimer > 0)
            {
                powerTimer--;
            }
            if (powerTimer == 0)
            {
                shootinglvl = 0;
            }

        }


    }
}
