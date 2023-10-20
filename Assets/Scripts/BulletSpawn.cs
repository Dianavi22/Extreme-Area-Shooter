using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject m_bulletPrefab;
 
    [SerializeField]
    private Transform m_bulletSpawnPoint;

    [SerializeField]
    private float m_bulletSpeed;

    [SerializeField]
    private float _bulletForce = 20f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(m_bulletPrefab, m_bulletSpawnPoint.position, m_bulletSpawnPoint.rotation);
            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
            rbBullet.AddForce(m_bulletSpawnPoint.forward * _bulletForce, ForceMode.Impulse);
            //bullet.GetComponent<Rigidbody>().velocity = m_bulletSpawnPoint.forward * m_bulletSpeed; 
        }
    }
}
