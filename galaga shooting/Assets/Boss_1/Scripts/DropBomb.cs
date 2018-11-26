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
    public float bombdelay;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        Debug.Log("countin down sucka!");
        bombTiming -= Time.deltaTime;
        if (bombTiming <= 0f)
        {
            //DROP TIME BOMB DROPPED AND CHASES PLAYER FOR..... 4.0f. IT WILL EXPLODE ONLY AFTER 4.0f so the sound bite can play for 4.0f. 
            //Bomb explosion script is in the bBomb PREFAB and its called the BombBehaviour.

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
        bombTiming = bombdelay;
        Debug.Log("resetting");
    }
}
