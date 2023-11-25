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

    [SerializeField] GameObject imageUlt1;
    [SerializeField] GameObject imageUlt2;
    [SerializeField] GameObject imageUlt3;
    [SerializeField] GameObject imageUlt4;
    [SerializeField] GameObject textUlt;

    public ParticleSystem flashLaser;
    public ParticleSystem sparksLaser;

    [SerializeField] ParticleSystem _ultBarPartSysteme;
    public ParticleSystem ultPartSysteme1;
    public ParticleSystem ultPartSysteme2;
    public ParticleSystem ultPartSysteme3;
    public ParticleSystem ultPartSysteme4;
    public ParticleSystem ultPartSysteme5;
    public ParticleSystem ultPartSide;

    public PostProcessVolume ultiPostProcess;
    [SerializeField] PlayerHealth _playerHealth;
    [SerializeField] EnemySpawner _enemySpawner;
    public bool isRevived;
    public GameObject ultiLight;

    public Animation _pulsAnimation;

    public bool isFirstTime = true;

    private int _difficult = 0;

    public ParticleSystem garlicParticules;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _laser;
    [SerializeField] private AudioClip _ultIsReadySound;

    [SerializeField] private MeshRenderer _playerPart1;
    [SerializeField] private MeshRenderer _playerPart2;
    [SerializeField] private MeshRenderer _playerPart3;
    [SerializeField] private MeshRenderer _playerPart4;
    [SerializeField] private Material _playerMaterial;

    bool _isPlayed = false;
    void Start()
    {
        slider.value = 0;
        _ultBarPartSysteme.Stop();
        isRevived = false;
        _nbBlink = 0;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _gameManager.isUltCharged && _playerHealth.isAlive)
        {
            VisuelUlti();
            _audioSource.PlayOneShot(_laser, 2f);
            _difficult++;
            UpSpawnRate();
            Garlic();
            ReInitLifeBar();
            _scale.LaunchUlti();
            _gameManager.ultCharge = 0;
            UpdateUltBar();
            _gameManager.isUltCharged = false;
            _gameManager.OldUltCharge = 0;

            _playerPart1.material = _playerMaterial;
            _playerPart2.material = _playerMaterial;
            _playerPart3.material = _playerMaterial;
            _playerPart4.material = _playerMaterial;


            if (_gameManager.playerLevelUpgrade < 90) {  _gameManager.playerLevelUpgrade = 90; }
        }
        if(radiusGarlic == 7)
        {
            colliders = Physics.OverlapSphere(_player.transform.position, radiusGarlic);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Destroy(collider.gameObject);

                }
            }
        }
        if (slider.value == 1)
        {
            _currentSliderMaterial.material = _sliderCompleteMaterial;
            _ultBarPartSysteme.Play();
           
            textUlt.SetActive(true);
            if (!_isPlayed)
            {
                ultPartSide.Play();
                StartCoroutine(BlinkGreen());
                _audioSource.PlayOneShot(_ultIsReadySound,1.5f);
                _playerPart1.material = _sliderCompleteMaterial;
                _playerPart2.material = _sliderCompleteMaterial;
                _playerPart3.material = _sliderCompleteMaterial;
                _playerPart4.material = _sliderCompleteMaterial;

                _isPlayed = true;
            }
        }
        else
        {
            _currentSliderMaterial.material = _sliderEmptyMaterial;
           
            textUlt.SetActive(false);
            _isPlayed = false;


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
            isFirstTime = false;
            _enemySpawner.ResetSpawnEnemy();
            _enemySpawner.m_Rate += 0.5f;
            _enemySpawner.m_RateBigEnemy += 0.5f;
            _enemySpawner.m_RateExploseEnemy += 0.5f;
        }
        _gameManager.maxUltCharge += 30;
        _enemySpawner.m_Rate *= 1.4f; 
        _enemySpawner.m_RateBigEnemy *= 1.4f; 
        _enemySpawner.m_RateExploseEnemy *= 1.4f;

       
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
        garlicParticules.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_player.transform.position, radiusGarlic);
    }

    private int _nbBlink;

    IEnumerator BlinkGreen()
    {
        while (_nbBlink < 4)
        {
            imageUlt1.SetActive(true);
            imageUlt2.SetActive(true);
            imageUlt4.SetActive(true);
            imageUlt3.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            imageUlt1.SetActive(false);
            imageUlt2.SetActive(false);
            imageUlt4.SetActive(false);
            imageUlt3.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            _nbBlink++;
        }
        imageUlt1.SetActive(false);
        imageUlt2.SetActive(false);
        imageUlt4.SetActive(false);
        imageUlt3.SetActive(false);
        _nbBlink = 0;
        yield return null;

    }

}
