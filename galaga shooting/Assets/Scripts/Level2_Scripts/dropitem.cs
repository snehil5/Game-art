using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dropitem : MonoBehaviour
{
    public GameObject dropItem;
    float speed = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(dropItem, transform.position, Quaternion.identity);
    }
    
}
