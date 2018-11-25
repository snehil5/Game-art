using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting1 : MonoBehaviour {

	public GameObject bulletPrefab;

	public float fireDelay = 0.25f;
	float cooldownTimer= 0;

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
        
        if (Input.GetButton ("Fire1")&& cooldownTimer <= 0) {
			Debug.Log("pew");
			cooldownTimer = fireDelay;
            Audio.PlaySound("shooting");
            Instantiate (bulletPrefab, transform.position, transform.rotation);
		}
	}
}
