using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Collider playercollision;
    private Collider bulletcollision;
    private Collider itemCollider;
    [SerializeField]
    public int m_DamageBullet = 1;
    void Start()
    {
        playercollision = FindObjectOfType<Player>().GetComponent<Collider>();
        bulletcollision = GetComponent<Collider>();

        StartCoroutine(DestroyBullet());
    }

    void Update()
    {
       // itemCollider = FindObjectOfType<Item>().GetComponent<Collider>();

        Physics.IgnoreCollision(playercollision, bulletcollision);
        Physics.IgnoreCollision(bulletcollision, bulletcollision);
       // Physics.IgnoreCollision(itemCollider, bulletcollision);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
