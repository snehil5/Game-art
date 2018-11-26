using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dropitem : MonoBehaviour
{
    public GameObject dropItem;
    float speed = 2f;
    DamageHandler droptop;
    Transform spot;

    private void Start()
    {
        droptop = gameObject.GetComponent<DamageHandler>();
    }

    public void Update()
    {
        //spot.transform.position = droptop.transform.position;
        if (droptop.health <= 0)
        {
            
            //Instantiate(dropItem, spot.transform.position, Quaternion.identity);
            Debug.Log("RAINDROP");
        }
    }
}


