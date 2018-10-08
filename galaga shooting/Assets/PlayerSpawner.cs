using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    public GameObject playerPrefab;
    GameObject playerInstance;

    public int numLives = 3;
    public int score;

    float respawnTimer;

	// Use this for initialization
	void Start () {
        score = 0;
        SpawnPlayer();
	}

    void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    // Update is called once per frame
    void Update () {
		if(playerInstance == null && numLives > 0)
        {
            respawnTimer -= Time.deltaTime;
            
            if(respawnTimer <-0)
            {
                SpawnPlayer();
            }
        }
	}

    void OnGUI()
    {
        if(numLives > 0 || playerInstance != null)
        {
            GUI.Label(new Rect(0, 0, 100, 50), "Lives Left " + numLives);
            GUI.Label(new Rect(20, 20, 100, 50), "Score: " + score);
        }
        else
        {
            GUI.Label(new Rect(Screen.width/2 -50, Screen.height/2 - 25, 100, 50), "Game Over!");
        }
    }
}
