using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Right_Left : MonoBehaviour
{

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;
    // Use this for initialization
    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * Time.deltaTime * speed);
        //Check to see if we have reached the Patrol Point 

        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f)
        {

            //if true we have reached the patrol point -now get the next one
            //check to see if we have any more patrol points if not go back to the first one
            if (currentPatrolIndex + 1 < patrolPoints.Length)
            {
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }
        // Turn to face the current patrol point 
        //finding the direction Vector that points to the patrolPoint 
        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        //Figure out the rotation in degrees that we need to turn torwards
       
        //Made the roation that we need to face
        
        //Apply the roation to our transform
        

    }

}

