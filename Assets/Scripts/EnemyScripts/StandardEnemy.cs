using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform _targetPlayer;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float m_StandardEnemySpeed;
    private Vector3 _enemyDir;

    [Header("HP")]
    [SerializeField] private int m_MaxHpEnemy;
    [SerializeField] private int m_CurrentHpEnemy;

    [Header("Damage")]
    [SerializeField] public int m_damageStandardEnemy = 3;
    public PlayerHealth _damage;

    [Header("Import")]
    private GameManager _gameManager;
    private Timer _timer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _targetPlayer = FindObjectOfType<Player>().transform;
        _damage = FindObjectOfType<Player>().GetComponent<PlayerHealth>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _timer = FindObjectOfType<Timer>().GetComponent<Timer>();
    }
    void Start()
    {
        m_CurrentHpEnemy = m_MaxHpEnemy;
    }

    void Update()
    {
        //Direction
        transform.position = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, m_StandardEnemySpeed * Time.deltaTime);
         _enemyDir = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, m_StandardEnemySpeed * Time.deltaTime);

        gameObject.transform.LookAt(_targetPlayer);
        //Rotation
        //Quaternion toRotation = Quaternion.LookRotation(_enemyDir, Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.deltaTime);
        if(_timer.seconds > 40)
        {
            m_StandardEnemySpeed = 6;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            _gameManager.standardEnemyKilled++;
            _gameManager.ultCharge++;
            _gameManager.playerLevelUpgrade++;
            _gameManager.playerScore = _gameManager.playerScore + 100;
        }
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            _damage.TakeDamage();
        }
    }

   
}
