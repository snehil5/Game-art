using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerSpawner : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject retry;
    public GameObject mainMenu;
    public GameObject live1, live2, live3;
    GameObject playerInstance;

    public float invulnPeriod = 0;
    float invulnTimer = 0;

    static public int numLives = 3;
    public int score;
    float timeLeft;
    float playTime;
    float respawnTimer;
    public int count = 0;

	// Use this for initialization
	void Start () {
        score = 0;
        playTime = 0;
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "SampleScene")
        {
            SpawnPlayer();
        }
        else
        {
            TransportPlayer();
        }
	}

    void TransportPlayer()
    {
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        if (invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            playerInstance.layer = 10;
        }
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

        if (numLives > 0)
        {
            playTime += Time.deltaTime;
        }

        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;
            StartCoroutine(Flash(0.1f, playerInstance));
            if (invulnTimer <= 0)
            {
                playerInstance.layer = 8;
            }
        }

        if (score >= 115 ) {
            
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
        switch (numLives)
        {
            case 3:
                live1.gameObject.SetActive(true);
                live2.gameObject.SetActive(true);
                live3.gameObject.SetActive(true);
                break;
            case 2:
                live1.gameObject.SetActive(true);
                live2.gameObject.SetActive(true);
                live3.gameObject.SetActive(false);
                break;

            case 1:
                live1.gameObject.SetActive(true);
                live2.gameObject.SetActive(false);
                live3.gameObject.SetActive(false);
                break;
            case 0:
                live1.gameObject.SetActive(false);
                live2.gameObject.SetActive(false);
                live3.gameObject.SetActive(false);
                break;
        }
	}

    void OnGUI()
    {
        if (numLives > 0 || playerInstance != null)
        {
            //GUI.Label(new Rect(0, 0, 100, 50), "Lives Left " + numLives);
            GUI.Label(new Rect(300, 20, 100, 50), " " + score);
            GUI.Label(new Rect(1300, 20, 100, 50), " " + (int)playTime + "s");
        }
        else
        {
            GUI.Label(new Rect(300, 20, 100, 50), " " + score);
            GUI.Label(new Rect(1300, 20, 100, 50), " " + (int)playTime + "s");
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game Over! Total Score:" + score + " Total Time:" + (int)playTime + "s");
            retry.SetActive(true);
            mainMenu.SetActive(true);
        }
    }
    public int getScore()
    {
        return score;
    }

    IEnumerator Flash(float x, GameObject player)
    {
        for (int i = 0; i < 10; i++)
        {
            if (player)
            {
                player.GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSeconds(x);
            }
            if (player)
            {
                player.GetComponent<SpriteRenderer>().enabled = true;
                yield return new WaitForSeconds(x);
            }
        }
    }

}
    