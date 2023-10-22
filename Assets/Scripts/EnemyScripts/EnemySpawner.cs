using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_StandardEnemyPrefab;

    [SerializeField]
    private GameObject m_ExploseEnemyPrefab;
    private float _lastSpawn;
    private float _lastSpawnExploseEnemy;

    [SerializeField]
    private float m_Width;

    [SerializeField]
    private float m_Rate;

    [SerializeField]
    private float m_RateExploseEnemy;

    [SerializeField]
    List<Spawner> spawners = new List<Spawner>();

    void Start()
    {
        _lastSpawn = Time.time;
        _lastSpawnExploseEnemy = Time.time;

    }

    void Update()
    {
        if ((Time.time - _lastSpawn) >= (1f / m_Rate))
        {
            _lastSpawn = Time.time;
            StandardEnemySpawn();
        }

        if ((Time.time - _lastSpawnExploseEnemy) >= (1f / m_RateExploseEnemy))
        {
            _lastSpawnExploseEnemy = Time.time;
            ExploseEnemySpawn();
        }
    }

    public void StandardEnemySpawn()
    {
        spawners[Random.Range(0, spawners.Count)].SpawnEnemy(m_StandardEnemyPrefab);
      
    }
    public void ExploseEnemySpawn()
    {
        spawners[Random.Range(0, spawners.Count)].SpawnEnemy(m_ExploseEnemyPrefab);
      
    }
}
