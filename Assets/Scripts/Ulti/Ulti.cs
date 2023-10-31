using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Ulti : MonoBehaviour
{
    public static Ulti ulti;
    [SerializeField] private GameManager _gameManager;

    [Header("Laser")]
    [SerializeField] private Scale _scale;

    [Header("Garlic")]
    public float radiusGarlic;
    [SerializeField] GameObject _player;

    [Header("UI")]
    [SerializeField] private Slider slider;
    [SerializeField] private Material _sliderEmptyMaterial;
    [SerializeField] private Image _currentSliderMaterial;
    [SerializeField] private Material _sliderCompleteMaterial;

    [SerializeField] Collider[] colliders;

    public ParticleSystem flashLaser;
    public ParticleSystem sparksLaser;

    [SerializeField] ParticleSystem _ultBarPartSysteme;
    public ParticleSystem ultPartSysteme1;
    public ParticleSystem ultPartSysteme2;
    public ParticleSystem ultPartSysteme3;
    public ParticleSystem ultPartSysteme4;
    public ParticleSystem ultPartSysteme5;

    public PostProcessVolume ultiPostProcess;
    [SerializeField] PlayerHealth _playerHealth;
    [SerializeField] EnemySpawner _enemySpawner;
    public bool isRevived;
    public GameObject ultiLight;

    public Animation _pulsAnimation;

    public bool isUltiBegin;
    public bool isFirstTime = true;

    private int _difficult = 0;



    void Start()
    {
        slider.value = 0;
        radiusGarlic = 0;
        _ultBarPartSysteme.Stop();
        isRevived = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _gameManager.isUltCharged && _playerHealth.isAlive)
        {
            VisuelUlti();
            _difficult++;
            isUltiBegin = true;
            UpSpawnRate();
            Garlic();
            ReInitLifeBar();
            _scale.LaunchUlti();
            _gameManager.ultCharge = 0;
            UpdateUltBar();
            _gameManager.isUltCharged = false;
            _gameManager.OldUltCharge = 0;
        }

        if(slider.value == 1)
        {
            _currentSliderMaterial.material = _sliderCompleteMaterial;
            _ultBarPartSysteme.Play();

        }
        else
        {
            _currentSliderMaterial.material = _sliderEmptyMaterial;

        }
        
    }

    public void VisuelUlti()
    {
        ultPartSysteme1.Play();
        ultPartSysteme2.Play();
        ultPartSysteme3.Play();
        ultPartSysteme4.Play();
        ultPartSysteme5.Play();

        _ultBarPartSysteme.Stop();

        ultiLight.SetActive(true);
        flashLaser.Play();
        sparksLaser.Play();

        ultiPostProcess.weight = 1;

    }

    public void UpSpawnRate()
    {
        if (isFirstTime)
        {
            _enemySpawner.m_Rate = 2f;
            _enemySpawner.m_RateExploseEnemy = 1f;
            _enemySpawner.m_RateBigEnemy = 0.6f;
        }
        isFirstTime = false;
        _gameManager.maxUltCharge += 10;
        _enemySpawner.m_Rate += 0.3f; 
        _enemySpawner.m_RateBigEnemy += 0.3f; 
        _enemySpawner.m_RateExploseEnemy += 0.3f;

       
    }

    public void ReInitLifeBar()
    {
        _playerHealth.m_currentHealth = _playerHealth.m_maxHealth;
        isRevived = true;
    }

    public void UpdateUltBar()
    {
        slider.value = _gameManager.ultCharge / _gameManager.maxUltCharge;
    }

    public void Garlic()
    {
        radiusGarlic = 7;
        colliders = Physics.OverlapSphere(_player.transform.position, radiusGarlic);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
               // print("ENEMY IN RADIUS");
                Destroy(collider.gameObject);

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_player.transform.position, radiusGarlic);
    }


}
