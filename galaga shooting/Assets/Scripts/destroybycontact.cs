using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybycontact : MonoBehaviour {
    public GameObject ExplosionGo; // explosion
    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayExplosion();
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGo);
        explosion.transform.position = transform.position;
    }
}
