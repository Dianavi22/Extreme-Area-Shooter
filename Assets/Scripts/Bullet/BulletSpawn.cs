using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject m_bulletPrefab;
    [SerializeField] private Transform m_bulletSpawnPoint;
    [SerializeField] private float m_bulletSpeed;
    [SerializeField] private float _bulletForce = 20f;
    [SerializeField] private float nextFire = 0.001f;
    [SerializeField] private float myTime = 0.0F;
    
    public float fireDelta;

    public static BulletSpawn bulletSpawn;

    [SerializeField] GameManager gameManager; 
    [SerializeField] Scale _scale; 

    [SerializeField] ItemManager _itemManager;

    [SerializeField] GameObject megaBalls;


    private void Start()
    {
        fireDelta = 0.3f;
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    void Update()
    {
        myTime = myTime + Time.deltaTime;
        if (Input.GetMouseButton(0) && myTime > nextFire && !_scale.isCurrentUlti && !_itemManager.isMegaBallsItem)
        {
            nextFire = myTime + fireDelta;
            Shoot();
            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
        else if(Input.GetMouseButton(0) && myTime > nextFire && !_scale.isCurrentUlti && _itemManager.isMegaBallsItem)
        {
            nextFire = myTime + fireDelta;
            SuperShoot();
            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }

        if(gameManager.playerLevelUpgrade >= 110)
        {
            fireDelta = 0.19f;
        }
        else
        {
            fireDelta = 0.3f;

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

    private void SuperShoot()
    {
        GameObject bullet = Instantiate(megaBalls, m_bulletSpawnPoint.position, m_bulletSpawnPoint.rotation);
        Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
        rbBullet.AddForce(m_bulletSpawnPoint.forward * _bulletForce, ForceMode.Impulse);
    }
}

