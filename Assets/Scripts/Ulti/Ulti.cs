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
    [SerializeField] private GameObject _player;

    [Header("UI UltBar")]
    [SerializeField] private Slider slider;
    [SerializeField] private Material _sliderEmptyMaterial;
    [SerializeField] private Image _currentSliderMaterial;
    [SerializeField] private Material _sliderCompleteMaterial;
    [SerializeField] private GameObject textUlt;

    [Header("UI Ult Ready")]
    [SerializeField] private GameObject imageUlt1;
    [SerializeField] private GameObject imageUlt2;
    [SerializeField] private GameObject imageUlt3;
    [SerializeField] private GameObject imageUlt4;
    [SerializeField] private ParticleSystem _ultBarPartSysteme;
    [SerializeField] private ParticleSystem ultPartSide;


    [Header("Player When Ulti is Ready")]
    [SerializeField] private MeshRenderer _playerPart1;
    [SerializeField] private MeshRenderer _playerPart2;
    [SerializeField] private MeshRenderer _playerPart3;
    [SerializeField] private MeshRenderer _playerPart4;
    [SerializeField] private Material _playerMaterial;


    [SerializeField] Collider[] colliders;

    public ParticleSystem flashLaser;
    public ParticleSystem sparksLaser;

    [Header("Particules Up Ulti")]
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

    public bool isFirstTime = true;


    public ParticleSystem garlicParticules;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _laser;
    [SerializeField] private AudioClip _ultIsReadySound;
    [SerializeField] private AudioClip _spaceBreakingSound;

    [Header("SpaceBreaker")]
    [SerializeField] private ParticleSystem _breakingSpace1;
    [SerializeField] private ParticleSystem _breakingSpace2;
    [SerializeField] private ParticleSystem _breakingSpace3;
    [SerializeField] private ParticleSystem _breakingSpace4;

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
            UpSpawnRate();
            Garlic();
            ReInitLifeBar();
            _scale.LaunchUlti();
            ReIntUltBar();
            ReInitPlayerGfx();
            if (_gameManager.playerLevelUpgrade < 90) {  _gameManager.playerLevelUpgrade = 90; }
            Invoke("SpaceBreak", 1.7f);
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
                PrepareUltiVisuel();
                ChangePlayerGfxForUlti();
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

    #region UltiReady
    public void PrepareUltiVisuel()
    {
        ultPartSide.Play();
        StartCoroutine(BlinkGreen());
        _audioSource.PlayOneShot(_ultIsReadySound, 0.17f);
    }
    public void ChangePlayerGfxForUlti()
    {
        _playerPart1.material = _sliderCompleteMaterial;
        _playerPart2.material = _sliderCompleteMaterial;
        _playerPart3.material = _sliderCompleteMaterial;
        _playerPart4.material = _sliderCompleteMaterial;
    }
    #endregion

    #region Ulti 
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

    public void VisuelUlti()
    {
        ultPartSysteme1.Play();
        ultPartSysteme2.Play();
        ultPartSysteme3.Play();
        ultPartSysteme4.Play();
        ultPartSysteme5.Play();
        _audioSource.PlayOneShot(_laser, 0.63f);

        _ultBarPartSysteme.Stop();

        ultiLight.SetActive(true);
        flashLaser.Play();
        sparksLaser.Play();

        ultiPostProcess.weight = 1;
    }


    #endregion

    #region Event After ulti
    public void UpSpawnRate()
    {
       
            if (isFirstTime)
            {
                isFirstTime = false;
                _enemySpawner.m_Rate += 0.6f;
                _enemySpawner.m_RateBigEnemy += 0.6f;
                _enemySpawner.m_RateExploseEnemy += 0.6f;
            _enemySpawner.ResetSpawnEnemy();

        }
        _enemySpawner.m_Rate *= 1.6f;
            _enemySpawner.m_RateBigEnemy *= 1.6f;
            _enemySpawner.m_RateExploseEnemy *= 1.6f;
                _enemySpawner.ResetSpawnEnemy();

        _gameManager.maxUltCharge += 30;
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
    public void ReIntUltBar()
    {
        UpdateUltBar();
        _gameManager.ultCharge = 0;
        _gameManager.isUltCharged = false;
        _gameManager.OldUltCharge = 0;
    }

    public void ReInitPlayerGfx()
    {

        _playerPart1.material = _playerMaterial;
        _playerPart2.material = _playerMaterial;
        _playerPart3.material = _playerMaterial;
        _playerPart4.material = _playerMaterial;
    }

    #endregion


    public void SpaceBreak()
    {
        _gameManager.wavesCount++;
        if (_gameManager.wavesCount == 1)
        {
            _breakingSpace1.Play();
            _audioSource.PlayOneShot(_spaceBreakingSound, 1.5f);
        }
        else if (_gameManager.wavesCount == 2)
        {
            _breakingSpace2.Play();
            _audioSource.PlayOneShot(_spaceBreakingSound, 1.5f);

        }
        else if (_gameManager.wavesCount == 3)
        {
            _breakingSpace3.Play();
            _audioSource.PlayOneShot(_spaceBreakingSound, 1.5f);

        }
        else if (_gameManager.wavesCount == 4)
        {
            _breakingSpace4.Play();
            _audioSource.PlayOneShot(_spaceBreakingSound, 1.5f);

        }
        else
        {
            _audioSource.PlayOneShot(_spaceBreakingSound, 1.5f);
        }
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
