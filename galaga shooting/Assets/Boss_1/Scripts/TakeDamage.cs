using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    public GameObject bulletprefab;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("GETTING HIT");
    }


}
