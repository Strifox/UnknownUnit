using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : Singleton<EnemySpawnerScript>
{
    public GameObject enemy;
    float randY;
    float randX;
    Vector2 wheretospawn;
    public int EnemyCount;
    public float StartWait;
    public float SpawnWait;
    public float WaveWait;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator EnemySpawner()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for (int i = 0; i < EnemyCount; i++)
            {
                randY = -2f;
                randX = -14.5f;
                wheretospawn = new Vector2(randX, randY);
                Instantiate(enemy, wheretospawn, Quaternion.identity);
                yield return new WaitForSeconds(SpawnWait);
            }
            yield return new WaitForSeconds(WaveWait);
        }
    }
}


