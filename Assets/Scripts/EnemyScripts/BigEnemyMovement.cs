using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyMovement : MonoBehaviour
{


    [SerializeField] private Transform _targetPlayer;
    [SerializeField] private Rigidbody _rb;
    private Vector3 _enemyDir;
    public float _bigEnemySpeed = 1.5f;

    [SerializeField] private Timer _timer;
    [SerializeField] private BigEnemy _bigEnemy;
    [SerializeField] private GameManager _gameManager;
    private void Awake()
    {
        try
        {

            _timer = FindObjectOfType<Timer>().GetComponent<Timer>();
            _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        }
        catch
        {
            return;
        }



    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _targetPlayer = FindObjectOfType<Player>().transform;
        Invoke("DestroyBigEnemy", 20) ;
    }

    void Update()
    {
        try
        {
            transform.Translate(Vector3.forward * _bigEnemySpeed * Time.deltaTime);

           // transform.position = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, _bigEnemySpeed * Time.deltaTime);
            _enemyDir = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, _bigEnemySpeed * Time.deltaTime);

            gameObject.transform.LookAt(_targetPlayer);



            if (_gameManager.isPhase2)
            {
                _bigEnemySpeed = 3.2f;
            }
        }
        catch
        {
            return;
        }
    }

    private void DestroyBigEnemy()
    {
        Destroy(gameObject);
    }
}

