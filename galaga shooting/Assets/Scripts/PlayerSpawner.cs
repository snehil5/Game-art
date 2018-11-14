using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerSpawner : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject retry;
    public GameObject mainMenu;

    GameObject playerInstance;

    public int numLives = 3;
    public int score;
    float timeLeft;
    float respawnTimer;
    public int count = 0;

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

        if (score >= 115)
        {
            timeLeft = 5.0f;
            
        }
    }

    // Update is called once per frame
    void Update () {

        if(score >= 115 ) {
            
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if (playerInstance == null && numLives > 0)
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
            GUI.Label(new Rect(Screen.width/2 -50, Screen.height/2 - 25, 100, 50), "Game Over! Total Score:" + score);
            retry.SetActive(true);
            mainMenu.SetActive(true);
        }
    }
    public int getScore()
    {
        return score;
    }
    
}
    