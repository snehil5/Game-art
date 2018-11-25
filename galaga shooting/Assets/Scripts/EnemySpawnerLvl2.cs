using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLvl2 : MonoBehaviour {
    public GameObject enemyGo;
    public GameObject asteroid1;
    public GameObject asteroid2;

    float maxSpawnSec = 3f;
    float maxAstSpawn = 10f;
    
	// Use this for initialization
	void Start () {
        Invoke("SpawnEnemy", maxSpawnSec);
        Invoke("SpawnAsteroid", maxAstSpawn);
        Invoke("SpawnAsteroid2", maxAstSpawn);
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(.2f, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(.8f, 1));
        GameObject anEnemy = (GameObject)Instantiate(enemyGo);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        ScheduleNextEnemySpawn();
    }

    void SpawnAsteroid()
    {
        Vector2 min2 = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max2 = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject anAst = (GameObject)Instantiate(asteroid1);
        anAst.transform.position = new Vector2(Random.Range(min2.x, max2.x), max2.y);
        
        ScheduleNextAstSpawn();
    }
    void SpawnAsteroid2()
    {
        Vector2 min3 = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max3 = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject anAst2 = (GameObject)Instantiate(asteroid2);
        anAst2.transform.position = new Vector2(Random.Range(min3.x, max3.x), max3.y);

        ScheduleNextAst2Spawn();
    }
    void ScheduleNextAstSpawn()
    {
        Invoke("SpawnAsteroid", maxAstSpawn);
    }
    void ScheduleNextAst2Spawn()
    {
        Invoke("SpawnAsteroid2", maxAstSpawn);
    }

    void ScheduleNextEnemySpawn()
    {
        Invoke("SpawnEnemy", maxSpawnSec);
    }
    
    
}
