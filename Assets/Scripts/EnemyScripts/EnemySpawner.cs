using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_StandardEnemyPrefab;
    [SerializeField]
    private GameObject m_BigEnemyPrefab;
    [SerializeField]
    private GameObject m_ExploseEnemyPrefab;
    private float _lastSpawn;
    private float _lastSpawnExploseEnemy;
    private float _lastSpawnBigEnemy;

    [SerializeField]
    private float m_Width;

    [SerializeField]
    private float m_Rate = 1.5f;

    [SerializeField]
    private float m_RateExploseEnemy = 0.5f;

    [SerializeField]
    private float m_RateBigEnemy = 0.3f;

    [SerializeField]
    List<Spawner> spawners = new List<Spawner>();

    private Timer _timer;

    private void Awake()
    {
        _timer = FindObjectOfType<Timer>().GetComponent<Timer>();

    }
    void Start()
    {
        _lastSpawn = Time.time;
        _lastSpawnExploseEnemy = Time.time;
        _lastSpawnBigEnemy = Time.time;

    }

    void Update()
    {
        if(_timer.seconds >= 40)
        {
            m_Rate = 2f;
            m_RateExploseEnemy = 1f;
            m_RateBigEnemy = 0.6f;
        }
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

        if ((Time.time - _lastSpawnBigEnemy) >= (1f / m_RateBigEnemy))
        {
            _lastSpawnBigEnemy = Time.time;
            BigEnemySpawn();
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
    public void BigEnemySpawn()
    {
        spawners[Random.Range(0, spawners.Count)].SpawnEnemy(m_BigEnemyPrefab);

    }
}
