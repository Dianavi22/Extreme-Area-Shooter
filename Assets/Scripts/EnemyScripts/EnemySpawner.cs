using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_StandardEnemyPrefab;
    private float _lastSpawn;

    [SerializeField]
    private float m_Width;

    [SerializeField]
    private float m_Rate;
    
    

    [SerializeField]
    List<Spawner> spawners = new List<Spawner>();

    void Start()
    {
        _lastSpawn = Time.time;

    }

    void Update()
    {
        if ((Time.time - _lastSpawn) >= (1f / m_Rate))
        {
            _lastSpawn = Time.time;
            StandardEnemySpawn();
        }
    }

    public void StandardEnemySpawn()
    {
        GameObject enemy = Instantiate(m_StandardEnemyPrefab, transform);
        enemy.transform.position = spawners[Random.Range(0,17)].transform.position;
    }
}
