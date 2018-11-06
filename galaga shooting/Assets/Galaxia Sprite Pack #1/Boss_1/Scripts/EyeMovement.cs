using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPosition;
    private Vector3 currentPos;
    private Vector3 moveDirection;
    private float eyeSpeed;

    // Use this for initialization
    void Start()
    {
        currentPos = transform.position;
        playerPosition = player.transform.position;
        moveDirection = (playerPosition - currentPos).normalized;
        
        eyeSpeed = 6.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position += moveDirection * eyeSpeed * Time.deltaTime;
        if(transform.position.x >= 10.5)
        {
            currentPos = transform.position;
            playerPosition = player.transform.position;
            transform.LookAt(playerPosition);
            moveDirection = (playerPosition - currentPos).normalized;
        }
        else if(transform.position.x <= -9.5)
        {
            currentPos = transform.position;
            playerPosition = player.transform.position;
            transform.LookAt(playerPosition);
            moveDirection = (playerPosition - currentPos).normalized;
        }
        else if(transform.position.y >= 5.5)
        {
            currentPos = transform.position;
            playerPosition = player.transform.position;
            transform.LookAt(playerPosition);
            moveDirection = (playerPosition - currentPos).normalized;
        }
        else if(transform.position.y <= -5.5)
        {
            currentPos = transform.position;
            playerPosition = player.transform.position;
            transform.LookAt(playerPosition);
            moveDirection = (playerPosition - currentPos).normalized;
        }
        
    }
}
