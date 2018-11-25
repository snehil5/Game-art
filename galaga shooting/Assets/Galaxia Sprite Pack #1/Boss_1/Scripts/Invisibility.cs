using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour {
    public Renderer render;
    float TBI = 5.0f;
   
    void Update () {
        TBI -= Time.deltaTime;
        if (TBI <= 0)
        {
            StartCoroutine(turnInvisible());
        }

    }
    IEnumerator turnInvisible()
    {
        render = GetComponent<Renderer>();
        Debug.Log("going invis");
        render.enabled = false;
        yield return new WaitForSeconds(5);
        render.enabled = true;
        TBI = 5.0f;
        Debug.Log("going back");
    }
}
