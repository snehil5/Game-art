using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargetheLaer : MonoBehaviour {

    public float chargedelay;
    float timebetweencharge = 4.0f;
    public Animator charginganim;
   
    // Update is called once per frame

    void Update () {
        timebetweencharge -= Time.deltaTime;
    

        if (timebetweencharge <= 0)
        {
            
            Debug.Log("Charge");
            timebetweencharge = chargedelay;

            charginganim.SetTrigger("charge");
        }
    }
}
