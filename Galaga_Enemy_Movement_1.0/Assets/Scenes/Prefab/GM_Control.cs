using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Control : MonoBehaviour
{
    //public Rigidbody2D enemy; //reference to itself
   // public float moveSpeed = 10.0f; //default move speed of the enemy
   
    public Transform enemyObj; // needs to be aware of the enemy
    
    
    // Use this for initialization
    void Start()
    {

        for (int xPos = -5; xPos < 1; xPos += 2)
            
        {
            for (int yPos = 5; yPos < 15; yPos += 3)

            {
                Instantiate(enemyObj, new Vector2(xPos, yPos), enemyObj.rotation);
                
            }
        }

        
    }
    // Update is called once per frame
    void Update()
    {

       
    }
    
    }
