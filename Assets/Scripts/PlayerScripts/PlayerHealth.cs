using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;

    [SerializeField]
    public float m_maxHealth = 5;
    public float m_currentHealth;
    public static PlayerHealth instance;

    private StandardEnemy standardEnemy;
    public static PlayerHealth _playerHealth;
    public bool isAlive = true;
    public GameManager _gameManager;

    [SerializeField]
    private CameraController _cameraController;

    [SerializeField]  private bool _isInvincible = false;

    public bool isTakingDamage;
    public GameObject lightHurt;
    public PostProcessVolume postProcessVolume;

    [SerializeField] private ParticleSystem _hurtParticuleSystem;
    public ParticleSystem hurtSideParticules1;
    public ParticleSystem hurtSideParticules2;
    public ParticleSystem hurtSideParticules3;
    public ParticleSystem hurtSideParticules4;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioSource _audioSourceGameOver;
    [SerializeField] AudioClip _hitSound;
    [SerializeField] AudioClip _lastHitSound;
    [SerializeField] AudioClip _gameOver;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
        //  _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        try
        {
            _cameraController.GetComponent<CameraController>();

        }
        catch
        {
            return ;
        }
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
            ParticulesDamage();
            _gameManager.combo = 0;
            m_currentHealth--;
            if (m_currentHealth <= 0)
            {
                if (!_gameManager.isPhase2) {_audioSourceGameOver.PlayOneShot(_gameOver, 3f);}
                else { _audioSourceGameOver.PlayOneShot(_gameOver, 4f);}
                isAlive = false;
            }

            if (!_gameManager.isPhase2 && m_currentHealth > 1) { _audioSource.PlayOneShot(_hitSound, 1f);} else { _audioSource.PlayOneShot(_hitSound, 2f);  }
            if (!_gameManager.isPhase2 && m_currentHealth == 1) { _audioSource.PlayOneShot(_lastHitSound, 1f);  } else if (_gameManager.isPhase2 && m_currentHealth == 1) { _audioSource.PlayOneShot(_lastHitSound, 2f); }
            healthBar.TakeDamageUI();
           
            _gameManager.playerLevelUpgrade = _gameManager.playerLevelUpgrade - 50;
            _isInvincible = true;
            StartCoroutine(Invincibility());

        }

    }

    public void TakeExplode()
    {

        if (!_isInvincible)
        {
            ParticulesDamage();
            if(m_currentHealth == 2) { m_currentHealth++; }
            m_currentHealth = m_currentHealth - 2;
            
            healthBar.TakeDamageUI();
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

    public void ParticulesDamage()
    {
        postProcessVolume.weight = 1;
        _cameraController.shakeshake = true;
        _cameraController.duration = 0.4f;
        lightHurt.SetActive(true);
        _hurtParticuleSystem.Play();
        hurtSideParticules1.Play();
        hurtSideParticules2.Play();
        hurtSideParticules3.Play();
        hurtSideParticules4.Play();
    }


}
