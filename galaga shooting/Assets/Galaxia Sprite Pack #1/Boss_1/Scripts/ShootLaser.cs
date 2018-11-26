using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour {

    public GameObject laserprefab;
    public float shootdelay;
    float timebetweenattack = 5.0f;
    public Animator eyeanimator;
   



    
    // Update is called once per frame
    void Update () {
        timebetweenattack -= Time.deltaTime;
       
        Vector3 laserposition = new Vector3(transform.position.x, transform.position.y -1.5f, transform.position.z);
        
        
      
        if (timebetweenattack <= 0)
        {
            eyeanimator.SetTrigger("shoot");
            Debug.Log("shootinglaser");
            timebetweenattack = shootdelay;

            Instantiate(laserprefab, laserposition, transform.rotation);
           

        }
       
    }
}
