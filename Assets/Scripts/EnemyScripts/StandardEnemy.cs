using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : MonoBehaviour
{
    
    [SerializeField]
    private float m_StandardEnemySpeed = 5f;

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

    //public static StandardEnemy standardEnemy;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _targetPlayer = FindObjectOfType<Player>().transform;
    }
    void Start()
    {
        m_CurrentHpEnemy = m_MaxHpEnemy;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, 3 * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

   
}
