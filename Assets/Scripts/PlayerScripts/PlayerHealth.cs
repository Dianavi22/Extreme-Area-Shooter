using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int m_maxHealth;
    [SerializeField]
    private int m_currentHealth;
    public static PlayerHealth instance;

    private StandardEnemy standardEnemy;
    public static PlayerHealth _playerHealth;
    public bool isAlive = true;
    public GameManager _gameManager;

    [SerializeField]
    private CameraController _cameraController;
    
    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
        //  _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _cameraController.GetComponent<CameraController>();
    }
    void Start()
    {
        m_currentHealth = m_maxHealth;

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy")) {
            TakeDamage(); 
        }
    }

  

    public void TakeDamage()
    {
        _cameraController.shakeshake = true;
        m_currentHealth = m_currentHealth - 5;
        if (m_currentHealth <= 0)
        {
            isAlive = false;
        }
        _gameManager.playerLevelUpgrade = _gameManager.playerLevelUpgrade - 50;
    }

    public void TakeExplode()
    {
        m_currentHealth = m_currentHealth - 20;
        if (m_currentHealth <= 0)
        {
            isAlive = false;
        }
        _gameManager.playerLevelUpgrade = _gameManager.playerLevelUpgrade - 50;

    }


}
