using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroybycontact : MonoBehaviour {
    public GameObject ExplosionGo; // explosion
   // private void OnTriggerEnter(Collider other)
   // {
        
     //   Destroy(gameObject);
    //}
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayExplosion();

        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "SecondLevel")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGo);
        explosion.transform.position = transform.position;
    }
}
