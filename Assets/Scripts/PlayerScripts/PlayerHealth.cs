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

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
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
            Debug.Log("AIL !");
            TakeDamage(); 
        }
    }

  

    public void TakeDamage()
    {
        m_currentHealth = m_currentHealth - 5;
        Debug.Log("HP Player : "+ m_currentHealth);
        if (m_currentHealth <= 0)
        {
            isAlive = false;
        }
    }

    
}
