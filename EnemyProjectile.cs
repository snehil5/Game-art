using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public Rigidbody2D projectile;
    public float moveSpeed = 15.0f;
	// Use this for initialization
	void Start () {
        projectile = this.gameObject.GetComponent<Rigidbody2D> ();

    }
	
	// Update is called once per frame
	void Update () {
        projectile.velocity = new Vector2(0, -1) * moveSpeed;
	}
}
