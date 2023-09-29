using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1;
    [SerializeField]float maxSpawnRate = 4f;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void SpawnEnemy ()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //khoi tao enemy
        GameObject Enemy = (GameObject)Instantiate(Enemy1);
        Enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //khoi tao lan spawn tiep theo
        ScheduleNextEnemySpawn();
    }
    void ScheduleNextEnemySpawn()
    {
        float spawnInSecond;
        if(maxSpawnRate > 1f)
        {
            spawnInSecond = Random.Range(1f, maxSpawnRate);
        }
        else
        {
            spawnInSecond = 1f;
        }
        Invoke("SpawnEnemy", spawnInSecond);
    }

    //tang do kho bang cach tao nhieu enemy
    void IncreaseSpawnRate()
    {
        if (maxSpawnRate > 1f)
            maxSpawnRate--;
        if (maxSpawnRate == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
    //bat dau spawn enemies
    public void ScheduleEnemySpawner()
    {
        Invoke("SpawnEnemy", maxSpawnRate);

        //tang do kho moi 20 giay
        InvokeRepeating("IncreaseSpawnRate", 0f, 20f);
    }

    //dung spawn enemies
    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
