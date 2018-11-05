using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	float maxSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


		Vector3 pos = transform.position;

		pos.y += Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;

		transform.position = pos;

		pos.x += Input.GetAxis ("Horizontal") * maxSpeed * Time.deltaTime;

		transform.position = pos;
	}
}
