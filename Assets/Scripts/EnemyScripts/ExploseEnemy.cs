using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploseEnemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]  private float m_ExploseEnemySpeed = 5f;
    [SerializeField] private Transform _targetPlayer;
    [SerializeField] private Rigidbody _rb;
    private Vector3 _enemyDir;

    [Header("HP")]
    [SerializeField] private int m_MaxHpEnemy;
    [SerializeField] private int m_CurrentHpEnemy;

    [SerializeField] public int m_damageStandardEnemy = 5;

    [Header("DamagePlayer")]
    public PlayerHealth _damage;
    public float explosionRadius = 4f;

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

        transform.position = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, m_ExploseEnemySpeed * Time.deltaTime);
        _enemyDir = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, m_ExploseEnemySpeed * Time.deltaTime);

        gameObject.transform.LookAt(_targetPlayer);

        if(_timer.seconds > 40)
        {
            m_ExploseEnemySpeed = 12;
        }
      
    }

    void ExplodeEnemy()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                _gameManager.playerScore = _gameManager.playerScore + 100;
                Destroy(gameObject);
                if(collider.gameObject.tag == "Enemy")
                {
                    Destroy(collider.gameObject);
                }
            }
        }
    }

    void ExplodePlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy" || collider.tag == "Player")
            {
                    Destroy(gameObject);
                if (collider.tag == "Enemy")
                {
                    Destroy(collider.gameObject);
                }
                else
                {
                    _damage.TakeExplode();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            _gameManager.playerLevelUpgrade = _gameManager.playerLevelUpgrade+5;
            ExplodeEnemy();
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            ExplodePlayer();
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
