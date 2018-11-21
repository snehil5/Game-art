using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

	float maxSpeed = 5f;
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = transform.position * -1f;

		Vector3 velocity = new Vector3 (0,  maxSpeed * Time.deltaTime, 0);
		pos += transform.rotation * velocity;

		transform.position = pos;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) { 
            Debug.Log("I AM HITTING THE PLAYER");
        }
    }





}
