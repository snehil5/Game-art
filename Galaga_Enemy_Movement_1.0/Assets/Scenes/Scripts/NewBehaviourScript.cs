using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehavior : MonoBehaviour {

    public float moveForce = 0f;
    private Rigidbody2D rbody;
    public Vector3 moveDir;
    public LayerMask RightWall,LeftWall;
    public float maxDistFromWall = 0f;


    void Start() {

        rbody = GetComponent<Rigidbody2D>();
        moveDir = ChooseDirection();
        transform.rotation = Quaternion.LookRotation(moveDir);
    }

    void Update()
    {
        rbody.velocity = moveDir * moveForce;


if (Physics.Raycast(transform.position, transform.forward,maxDistFromWall, RightWall))
        {
            moveDir = ChooseDirection();
            transform.rotation = Quaternion.LookRotation(moveDir);

        }
    }

    Vector3 ChooseDirection()
    {
        System.Random ran = new System.Random();
        int i = ran.Next(0, 3);

        Vector3 temp = new Vector3();

        if(i==0)
        {
            temp = transform.forward;
        }

        else if(i==1)
        {

            temp = -transform.forward;
        }

        else if (i == 2)
        {

            temp = transform.right;
        }
        else if (i == 1)
        {

            temp = -transform.right;
        }

        return temp;
    }


     
}