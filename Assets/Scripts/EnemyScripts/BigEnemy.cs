using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{

    [SerializeField]
    private float m_ExploseEnemySpeed = 5f;

    [SerializeField]
    private int m_MaxHpBigEnemy = 5;

    [SerializeField]
    private int m_CurrentHpBigEnemy;

    [SerializeField]
    private Transform _targetPlayer;

    [SerializeField]
    private Rigidbody _rb;

    public PlayerHealth _damage;

    private Vector3 _enemyDir;

    private float _bigEnemySpeed = 2;

    [SerializeField]  private List<Spawner> spawners = new List<Spawner>();

    private GameManager _gameManager;

    [SerializeField] private GameObject _littleStandardEnemy;

    [SerializeField] private Bullet _bullet;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _targetPlayer = FindObjectOfType<Player>().transform;
        _damage = FindObjectOfType<Player>().GetComponent<PlayerHealth>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();


    }
    void Start()
    {

        m_CurrentHpBigEnemy = m_MaxHpBigEnemy;
    }

    // Update is called once per frame
    void Update()
    {
      

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _damage.TakeDamage();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            _bullet = collision.collider.GetComponent<Bullet>();

            TakeDamageBigEnemy();
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
