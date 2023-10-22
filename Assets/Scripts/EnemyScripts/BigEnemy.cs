using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{

    [SerializeField]
    private float m_ExploseEnemySpeed = 5f;

    [SerializeField]
    private int m_MaxHpEnemy;

    [SerializeField]
    private int m_CurrentHpEnemy;

    


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
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _targetPlayer = FindObjectOfType<Player>().transform;
        _damage = FindObjectOfType<Player>().GetComponent<PlayerHealth>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    void Start()
    {
        
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
