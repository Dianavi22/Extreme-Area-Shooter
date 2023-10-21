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
    [SerializeField]
    private float nextFire = 0.001f;
    [SerializeField]
    private float myTime = 0.0F;
    [SerializeField]
    public float fireDelta = 0f;  

    void Update()
    {
        myTime = myTime + Time.deltaTime;
        if (Input.GetMouseButton(0) && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            Shoot();
            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }


    private void FixedUpdate()
    {
      
    }
    private void Shoot()
    {
            GameObject bullet = Instantiate(m_bulletPrefab, m_bulletSpawnPoint.position, m_bulletSpawnPoint.rotation);
            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
            rbBullet.AddForce(m_bulletSpawnPoint.forward * _bulletForce, ForceMode.Impulse);
    }
}

