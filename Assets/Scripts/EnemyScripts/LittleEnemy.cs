using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleEnemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform _targetPlayer;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float m_LittleEnemySpeed;
    private Vector3 _enemyDir;

    [Header("HP")]
    [SerializeField] private int m_MaxHpEnemy;
    [SerializeField] private int m_CurrentHpEnemy;

    [Header("Damage")]
    [SerializeField] public int m_damageLittleEnemy = 1;
    public PlayerHealth _damage;

    [Header("Import")]
    private GameManager _gameManager;
    private Timer _timer;

    [SerializeField] ParticleSystem _killParticules;
    [SerializeField] GameObject _gfxLittleEnemy;
    [SerializeField] Collider _collider;

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
        transform.position = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, m_LittleEnemySpeed * Time.deltaTime);
        _enemyDir = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, m_LittleEnemySpeed * Time.deltaTime);

        gameObject.transform.LookAt(_targetPlayer);
        //Rotation
        //Quaternion toRotation = Quaternion.LookRotation(_enemyDir, Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.deltaTime);
        if (_timer.seconds > 45.8)
        {
            m_LittleEnemySpeed = 6.3f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            _killParticules.Play();
            _collider.enabled = false;
            _gfxLittleEnemy.SetActive(false);
            Invoke("DestroyLittleEnemy", 1f);
           
        }
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            _damage.TakeDamage();
        }
        if (collision.collider.CompareTag("Ulti"))
        {
            _killParticules.Play();
            _collider.enabled = false;
            _gfxLittleEnemy.SetActive(false);
            Invoke("DestroyLittleEnemy", 1f);

        }
    }

    private void DestroyLittleEnemy()
    {
        _gameManager.littleEnemyKilled++;
        _gameManager.playerLevelUpgrade++;
        _gameManager.playerScore = _gameManager.playerScore + 50;
        _gameManager.ultCharge++;
        Destroy(gameObject);

    }


}
