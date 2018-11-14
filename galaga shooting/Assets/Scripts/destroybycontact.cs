using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybycontact : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
