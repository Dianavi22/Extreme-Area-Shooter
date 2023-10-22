using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyMovement : MonoBehaviour
{


    [SerializeField]
    private Transform _targetPlayer;

    [SerializeField]
    private Rigidbody _rb;
    private Vector3 _enemyDir;

    public PlayerHealth _damage;

    private float _bigEnemySpeed = 2;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _targetPlayer = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, _bigEnemySpeed * Time.deltaTime);
        _enemyDir = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, _bigEnemySpeed * Time.deltaTime);
        gameObject.transform.LookAt(_targetPlayer);
    }
}
