using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovement : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPosition;
    private Vector3 currentPos;
    private Vector3 moveDirection;
    private float eyeSpeed;
    public GameObject destroyeffect;
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentPos = transform.position;
        playerPosition = player.transform.position;
        moveDirection = (playerPosition - currentPos).normalized;
        
        eyeSpeed = 5.5f;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("KAMIKAZE");
            Destroy(Instantiate(destroyeffect, transform.position, Quaternion.identity), 1.0f);
            Destroy(gameObject);
        }
    }
}
