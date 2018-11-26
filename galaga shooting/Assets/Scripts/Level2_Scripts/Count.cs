using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour {

    private PlayerShooting2 player;
    public int powerTimer;

    // Use this for initialization
    void Start () {
        player = gameObject.GetComponent<PlayerShooting2>();
	}

    public IEnumerator StartCountdown(int powerTime)
    {
        powerTimer = powerTime;
        while (powerTimer > 0)
        {
            Debug.Log("Countdown: " + powerTimer);
            yield return new WaitForSeconds(1.0f);
            powerTimer--;
        }
        player.shootinglvl = 0;
    }
}
