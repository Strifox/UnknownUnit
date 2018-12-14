using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {


    public GameObject enemy;
    float randY;
    float randX;
    Vector2 wheretospawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    int waveEnemies = 30;
    int amountOfEnemies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > nextSpawn && waveEnemies > amountOfEnemies)
        {
            nextSpawn = Time.time + spawnRate;
            randY = -2f;
            randX = -14.5f;
            wheretospawn = new Vector2(randX, randY);
            Instantiate(enemy, wheretospawn, Quaternion.identity);
            amountOfEnemies++;
        }
	}
}
