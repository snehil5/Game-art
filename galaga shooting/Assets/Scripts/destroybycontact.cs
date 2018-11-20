using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybycontact : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
