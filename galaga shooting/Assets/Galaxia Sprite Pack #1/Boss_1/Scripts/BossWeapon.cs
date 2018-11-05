using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour {

    public Transform fireSpot;
    public Transform fireSpot_2;
    public Transform fireSpot_3;
    public Transform fireSpot_4;
    public Transform fireSpot_5;
    public Transform fireSpot_6;
    public Transform fireSpot_7;
    public Transform fireSpot_8;
    public GameObject laserFire;
    public GameObject warningShot;
    public float timer = 4f; 

	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        
        if(timer <= 0f)
        {
            StartCoroutine(bossShoot());
            timer = 4f;
        }
        

    }

    IEnumerator bossShoot ()
    {
        int randomFire = Random.Range(1,8);
        if (randomFire == 1)
        {
            Destroy(Instantiate(warningShot, fireSpot.position, fireSpot.rotation), 1f);
            yield return new WaitForSeconds(1);
            Destroy(Instantiate(laserFire, fireSpot.position, fireSpot.rotation), 3f);
        }
        else if (randomFire == 2)
        {
            Destroy(Instantiate(warningShot, fireSpot_2.position, fireSpot_2.rotation), 1f);
            yield return new WaitForSeconds(1);
            Destroy(Instantiate(laserFire, fireSpot_2.position, fireSpot_2.rotation),3f);
        }
        else if (randomFire == 3)
        {
            Destroy(Instantiate(warningShot, fireSpot_3.position, fireSpot_3.rotation), 1f);
            yield return new WaitForSeconds(1);
            Destroy(Instantiate(laserFire, fireSpot_3.position, fireSpot_3.rotation), 3f);
        }
        else if (randomFire == 4)
        {
            Destroy(Instantiate(warningShot, fireSpot_4.position, fireSpot_4.rotation), 1f);
            yield return new WaitForSeconds(1);
            Destroy(Instantiate(laserFire, fireSpot_4.position, fireSpot_4.rotation), 3f);
        }
        else if (randomFire == 5)
        {
            Destroy(Instantiate(warningShot, fireSpot_5.position, fireSpot_5.rotation), 1f);
            yield return new WaitForSeconds(1);
            Destroy(Instantiate(laserFire, fireSpot_5.position, fireSpot_5.rotation), 3f);
        }
        else if (randomFire == 6)
        {
            Destroy(Instantiate(warningShot, fireSpot_6.position, fireSpot_6.rotation), 1f);
            yield return new WaitForSeconds(1);
            Destroy(Instantiate(laserFire, fireSpot_6.position, fireSpot_6.rotation), 3f);
        }
        else if (randomFire == 7)
        {
            Destroy(Instantiate(warningShot, fireSpot_7.position, fireSpot_7.rotation), 1f);
            yield return new WaitForSeconds(1);
            Destroy(Instantiate(laserFire, fireSpot_7.position, fireSpot_7.rotation), 3f);
        }
        else
        {
            Destroy(Instantiate(warningShot, fireSpot_8.position, fireSpot_8.rotation), 1f);
            yield return new WaitForSeconds(1);
            Destroy(Instantiate(laserFire, fireSpot_8.position, fireSpot_8.rotation), 3f);
        }
    }
}
