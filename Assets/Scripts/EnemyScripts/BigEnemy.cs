using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    [Header("HP")]
    [SerializeField] private int m_MaxHpBigEnemy = 5;
    [SerializeField] private int m_CurrentHpBigEnemy;

    [Header("DamageByBigEnemy")]
    public PlayerHealth _damage;
    [SerializeField] private List<Spawner> spawners = new List<Spawner>();
    [SerializeField] private GameObject _littleStandardEnemy;
    [SerializeField] private Bullet _bullet;

    [Header("Imports")]
    private GameManager _gameManager;
    [SerializeField] private Timer _timer;
    private void Awake()
    {
        _damage = FindObjectOfType<Player>().GetComponent<PlayerHealth>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _timer = FindObjectOfType<Timer>().GetComponent<Timer>();
    }
    void Start()
    {
        m_CurrentHpBigEnemy = m_MaxHpBigEnemy;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            _bullet = collision.collider.GetComponent<Bullet>();

            TakeDamageBigEnemy();
        }
        if (collision.collider.CompareTag("Player"))
        {
            _damage.TakeDamage();
            Destroy(gameObject);
        }
    }

    private void TakeDamageBigEnemy()
    {
        m_CurrentHpBigEnemy = m_CurrentHpBigEnemy - _bullet.m_DamageBullet;
        if(m_CurrentHpBigEnemy <= 0)
        {
            _gameManager.playerLevelUpgrade = _gameManager.playerLevelUpgrade + 3;
            EnemySpawn();
            DestroyBigEnemy();
        }
    }

    private void DestroyBigEnemy()
    {
        Destroy(gameObject);
    }

    private void EnemySpawn()
    {
        for (int i = 0; i < spawners.Count; i++)
        {
            Instantiate(_littleStandardEnemy, spawners[i].transform);
        }
    }
}
