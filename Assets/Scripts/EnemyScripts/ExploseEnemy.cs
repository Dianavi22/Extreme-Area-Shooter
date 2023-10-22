using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploseEnemy : MonoBehaviour
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

    public float explosionRadius = 4f;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _targetPlayer = FindObjectOfType<Player>().transform;
        _damage = FindObjectOfType<Player>().GetComponent<PlayerHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHpEnemy = m_MaxHpEnemy;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, 5 * Time.deltaTime);
        _enemyDir = Vector3.MoveTowards(this.transform.position, _targetPlayer.position, 5 * Time.deltaTime);

        gameObject.transform.LookAt(_targetPlayer);

    }

    void ExplodeEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Destroy(gameObject);
                if(collider.gameObject.tag == "Enemy")
                {
                    Destroy(collider.gameObject);

                }
                // _damage.TakeDamage();
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
        if (other.CompareTag("Player"))
        {
            ExplodePlayer();
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            ExplodeEnemy();
            Destroy(gameObject);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
