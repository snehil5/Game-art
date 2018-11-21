using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShooting : MonoBehaviour {

    public GameObject laserprefab;
    public float shootdelay;
    float timebetweenattack = 5.0f;

    

    // Update is called once per frame
    void Update()
    {
        timebetweenattack -= Time.deltaTime;

        Vector3 laserposition = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
        

        if (timebetweenattack <= 0)
        {
            
            timebetweenattack = shootdelay;

            Instantiate(laserprefab, laserposition, transform.rotation);
            

        }

    }
}
