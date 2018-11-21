using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1Explosion : MonoBehaviour
{
    public GameObject ExplosionGo; // explosion

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayExplosion();
    }
    public void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGo);
        explosion.transform.position = transform.position;
    }
}
