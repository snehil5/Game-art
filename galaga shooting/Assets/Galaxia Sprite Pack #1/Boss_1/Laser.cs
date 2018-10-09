using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float laserSpeed = 20f;
    public Rigidbody2D shootDown;
    void Start()
    {

        shootDown.velocity = transform.up * laserSpeed;
    }

}
