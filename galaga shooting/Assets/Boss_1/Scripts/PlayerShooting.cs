using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject bulletPrefab;
	public float fireDelay = 0.25f;
	float cooldownTimer= 0;

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

        Vector3 bulletposition = new Vector3(transform.position.x, transform.position.y + 0.60f, transform.position.z);

		if (Input.GetButton ("Fire1")&& cooldownTimer <= 0) {
			Debug.Log("pew");
			cooldownTimer = fireDelay;

			Instantiate(bulletPrefab, bulletposition, transform.rotation);
		}
	}

  
}
