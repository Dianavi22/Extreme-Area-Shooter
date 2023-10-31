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
    [SerializeField] private ParticleSystem _sparks;
    [SerializeField] private Collider _collider;
    [SerializeField] private GameObject _gfx;

    [Header("Damage")]
    [SerializeField] public int m_damageStandardEnemy = 3;
    public PlayerHealth _damage;

    [Header("Import")]
    private GameManager _gameManager;
    private Timer _timer;

    private bool _isDestroy = false; 

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _targetPlayer = FindObjectOfType<Player>().transform;
        _damage = FindObjectOfType<Player>().GetComponent<PlayerHealth>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _timer = FindObjectOfType<Timer>().GetComponent<Timer>();
        _sparks = GetComponentInChildren<ParticleSystem>();
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

        if (!_isDestroy)
        {
            gameObject.transform.LookAt(_targetPlayer);
        }
        //Rotation
        //Quaternion toRotation = Quaternion.LookRotation(_enemyDir, Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.deltaTime);
        if (_timer.seconds > 45.8)
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
            _isDestroy = true;
            _collider.enabled = false;
            _rb.freezeRotation = true;
            m_StandardEnemySpeed = 0;
            _gfx.SetActive(false);
            _sparks.Play();
            Invoke("DieEnemy", 0.5f);
           
        }
        if (collision.collider.CompareTag("Player"))
        {
            _isDestroy = true;
            _sparks.Play();
            Destroy(gameObject);
            _damage.TakeDamage();
        }
        if (collision.collider.CompareTag("Ulti"))
        {
            _isDestroy = true;
            _collider.enabled = false;
            _rb.freezeRotation = true;
            m_StandardEnemySpeed = 0;
            _gfx.SetActive(false);
            _sparks.Play();
            Invoke("DieEnemy", 0.5f);
        }
    }

    private void DieEnemy()
    {
        Destroy(gameObject);
        _gameManager.combo++;
        _gameManager.standardEnemyKilled++;
        _gameManager.ultCharge++;
        _gameManager.playerLevelUpgrade++;
        _gameManager.playerScore = _gameManager.playerScore + 100;
    }

   
}
