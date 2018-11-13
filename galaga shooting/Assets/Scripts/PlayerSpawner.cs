using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour {

    public GameObject playerPrefab;
    GameObject playerInstance;
    public int currentscenenumber;

    public int numLives = 3;
    public int score;
    public Button restartbutton;

    float respawnTimer;

	// Use this for initialization
	void Start () {
        score = 0;
        SpawnPlayer();
        restartbutton.enabled = false;
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

        RestartGame();





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
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 25, 200, 150), "Press R to restart!");
            
        }
    }

    public void RestartGame()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
