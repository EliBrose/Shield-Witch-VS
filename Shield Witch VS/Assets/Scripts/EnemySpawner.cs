using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public int enemyCount;
    public GameObject[] enemyPrefabs;

    private List<GameObject> enemiesLimit;

    public float enemySpawnRate;

    public int ramp;

    void Awake()
    {
        ramp = 10;
    }
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(transform.parent == player.transform)
        {
            //Debug.Log("Player is parent");
            InvokeRepeating("SpawnEnemy", 5f, enemySpawnRate);
        }
        else
        {
            SpawnEnemy();
        }
    }

    void FixedUpdate()
    {
        if(Time.time > ramp)
        {
            ramp += 30;
            enemyCount++;
        }
    }

    void SpawnEnemy()
    {
        GameObject[] enemyCounter = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyCounter.Length < 100)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 rand = Random.insideUnitCircle;
                rand.x = 5 * rand.x + (Mathf.Sign(rand.x) * 4);
                rand.y = 5 * rand.y + (Mathf.Sign(rand.y) * 4);
                int which = Random.Range(0, 10);
                GameObject enemy = Instantiate(enemyPrefabs[which], transform.position + rand, Quaternion.identity) as GameObject;
            }
        }
    }
}
