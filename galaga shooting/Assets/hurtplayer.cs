using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtplayer : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("IM HURT");
        }

    }

}
