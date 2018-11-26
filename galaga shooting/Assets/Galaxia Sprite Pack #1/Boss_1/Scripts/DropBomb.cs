using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour {

    public GameObject bBomb;
    public GameObject player;
    private Vector3 playerPosition;
    private Vector3 currentPos;
    private Vector3 moveDirection;
    float bombTiming = 5.0f;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        Debug.Log("countin down sucka!");
        bombTiming -= Time.deltaTime;
        if (bombTiming <= 0f)
        {
            dropBomb();
        }
    }
    void dropBomb()
    {
        Debug.Log("droppin bombs");
        GameObject bomb = Instantiate(bBomb, transform.position, transform.rotation);
        player = GameObject.FindGameObjectWithTag("Player");
        currentPos = transform.position;
        playerPosition = player.transform.position;
        moveDirection = (playerPosition - currentPos).normalized;
        var angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position += moveDirection * 4.0f * Time.deltaTime;
        bombTiming = 5.0f;
        Debug.Log("resetting");
    }
}
