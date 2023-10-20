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
    }
}
