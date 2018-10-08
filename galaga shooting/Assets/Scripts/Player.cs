using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 20.0f;

    public Rigidbody2D player;


	// Use this for initialization
	void Start () {
        player = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
	}
    
    public void MovePlayer()
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;

    }
}
