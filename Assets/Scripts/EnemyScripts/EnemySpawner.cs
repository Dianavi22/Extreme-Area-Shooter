using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_StandardEnemyPrefab;
    [SerializeField] private GameObject m_BigEnemyPrefab;
    [SerializeField] private GameObject m_ExploseEnemyPrefab;
    private float _lastSpawn;
    private float _lastSpawnExploseEnemy;
    private float _lastSpawnBigEnemy;

    [SerializeField] private float m_Width;

    public float m_Rate = 1.7f;
    public float m_RateExploseEnemy = 0.7f;
    public float m_RateBigEnemy = 0.5f;

    public float current_Rate = 1.5f;
    public float current_RateExploseEnemy = 0.5f;
    public float current_RateBigEnemy = 0.3f;

    [SerializeField] List<Spawner> spawners = new List<Spawner>();

    private Timer _timer;

    private bool _isSpeedEnemyWave = true;
    private bool _isBigEnemyWave = true;

    [SerializeField] EventManager _eventManager;
    [SerializeField] Ulti _ulti;
    public static EnemySpawner enemySpawner;
    private void Awake()
    {
        _timer = FindObjectOfType<Timer>().GetComponent<Timer>();

    }
    void Start()
    {
        ResetTimeSpawn();
    }

    void Update()
    {
        //if (_timer.seconds >= 60 && !_eventManager.isCurrentEvent)
        //{
        //    current_Rate = m_Rate;
        //    current_RateExploseEnemy = m_RateExploseEnemy;
        //    current_RateBigEnemy = m_RateBigEnemy;
        //}

        if ((Time.time - _lastSpawn) >= (1f / current_Rate))
        {
            _lastSpawn = Time.time;
            StandardEnemySpawn();
        }
        StartCoroutine(WaitingEnemyWave());

        if (_isSpeedEnemyWave)
        {
            return;
        }
        else
        {
            SpawnSpeedEnemy();
        }

        if (_isBigEnemyWave)
        {
            return;
        }
        else
        {
            SpawnBigEnemy();
        }


    }

    public void StandardEnemySpawn() { spawners[Random.Range(0, spawners.Count)].SpawnEnemy(m_StandardEnemyPrefab); }
    public void ExploseEnemySpawn() { spawners[Random.Range(0, spawners.Count)].SpawnEnemy(m_ExploseEnemyPrefab); }
    public void BigEnemySpawn() { spawners[Random.Range(0, spawners.Count)].SpawnEnemy(m_BigEnemyPrefab); }

    public void ResetTimeSpawn() {
        _lastSpawn = Time.time;
        _lastSpawnExploseEnemy = Time.time;
        _lastSpawnBigEnemy = Time.time;
    }

    public void SpawnSpeedEnemy()
    {
        if ((Time.time - _lastSpawnExploseEnemy) >= (1f / current_RateExploseEnemy))
        {
            _lastSpawnExploseEnemy = Time.time;
            ExploseEnemySpawn();
        }
    }

    public void SpawnBigEnemy()
    {
        if ((Time.time - _lastSpawnBigEnemy) >= (1f / current_RateBigEnemy))
        {

            _lastSpawnBigEnemy = Time.time;
            BigEnemySpawn();
        }
    }

   
    IEnumerator WaitingEnemyWave()
    {
        if(_isSpeedEnemyWave && _isBigEnemyWave)
        yield return new WaitForSeconds(10f);
        _isSpeedEnemyWave = false;
        yield return new WaitForSeconds(20f);
        _isBigEnemyWave = false;
    }

    public void ResetSpawnEnemy()
    {
        current_Rate = m_Rate;
        current_RateExploseEnemy = m_RateExploseEnemy;
        current_RateBigEnemy = m_RateBigEnemy;
    }
}
