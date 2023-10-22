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
    public int m_damageStandardEnemy = 5;


    [SerializeField]
    private Transform _targetPlayer;

    [SerializeField]
    private Rigidbody _rb;

    public PlayerHealth _damage;

    private Vector3 _enemyDir;

    private float _bigEnemySpeed = 2;

    [SerializeField]  private List<Spawner> spawners = new List<Spawner>();

    private GameManager _gameManager;

    [SerializeField] private GameObject _standardEnemy;

    [SerializeField] private List<StandardEnemy> standardEnemies;
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
        transform.position = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, _bigEnemySpeed * Time.deltaTime);
        _enemyDir = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, _bigEnemySpeed * Time.deltaTime);

        gameObject.transform.LookAt(_targetPlayer);

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            EnemySpawn();
            _bigEnemySpeed = 0;
            Invoke("DestroyBigEnemy", 0.3f);
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
            Instantiate(_standardEnemy, spawners[i].transform);
        }
    }
}
