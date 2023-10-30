using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;

    [SerializeField]
    public float m_maxHealth = 60;
    public float m_currentHealth;
    public static PlayerHealth instance;

    private StandardEnemy standardEnemy;
    public static PlayerHealth _playerHealth;
    public bool isAlive = true;
    public GameManager _gameManager;

    [SerializeField]
    private CameraController _cameraController;

    private bool _isInvincible = false;

    public bool isTakingDamage;
    public GameObject lightHurt;
    public PostProcessVolume postProcessVolume;

    [SerializeField] private ParticleSystem _hurtParticuleSystem;

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
           // TakeDamage(); 
        }
    }

  

    public void TakeDamage()
    {
        if (!_isInvincible)
        {
            _hurtParticuleSystem.Play();
            lightHurt.SetActive(true);
            postProcessVolume.weight = 1;
            _cameraController.shakeshake = true;
            _cameraController.duration = 0.4f;
            healthBar.damage = 5;
            healthBar.TakeDamageUI();
            m_currentHealth = m_currentHealth - 5;
            if (m_currentHealth <= 0)
            {
                isAlive = false;
            }
           
            _gameManager.playerLevelUpgrade = _gameManager.playerLevelUpgrade - 50;
            _isInvincible = true;
            StartCoroutine(Invincibility());

        }

    }

    public void TakeExplode()
    {

        if (!_isInvincible)
        {

            _cameraController.shakeshake = true;
            healthBar.damage = 15;
            healthBar.TakeDamageUI();
            m_currentHealth = m_currentHealth - 15;
            if (m_currentHealth <= 0)
            {
                isAlive = false;
            }
           
            _gameManager.playerLevelUpgrade = _gameManager.playerLevelUpgrade - 50;
            _isInvincible = true;
            StartCoroutine(Invincibility());
        }
    }

    public IEnumerator Invincibility()
    {
        yield return new WaitForSeconds(1.5f);
        _isInvincible = false;
    }


}
