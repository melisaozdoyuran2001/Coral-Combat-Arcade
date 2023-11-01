using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies; 
    public float spawnRate = 2f; 

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            
            int randomIndex = Random.Range(0, enemies.Length);
            GameObject enemyToSpawn = enemies[randomIndex];

            float spawnX = Random.Range(-8.0f, 8.0f); 
            Vector3 spawnPosition = new Vector3(spawnX, 6.0f, 0);

            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

            nextSpawnTime = Time.time + spawnRate;
            if( spawnRate >0.5)
            {
                 spawnRate -= 0.03f;
            }
           
        }
    }

  
}

