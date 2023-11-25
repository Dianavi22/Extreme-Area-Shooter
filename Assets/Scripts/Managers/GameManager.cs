using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Other scripts")]
    [SerializeField, HideInInspector] private PlayerHealth _playerHealth;
    [SerializeField, HideInInspector] private UIIncons _uiIcons;
    [SerializeField, HideInInspector] private BulletSpawn _bulletSpawn;
    [SerializeField] private Timer _timer;

    public static GameManager gameManager;
    [SerializeField] CameraController _cameraController;
    private PlayerController _playerController;
    [SerializeField] GameObject _itemSpawners;  

    [Header("Scoring")]
    [SerializeField] TMP_Text _playerScoreUI;
    public int playerScore;

    [Header("Weapon")]
    [SerializeField, HideInInspector] private GameObject _canon2;
    [SerializeField, HideInInspector] private GameObject _canon3;
    [SerializeField, HideInInspector] private GameObject _canon4;
    [SerializeField] private ParticleSystem _upgradePartSysteme1;
    [SerializeField] private ParticleSystem _upgradePartSysteme2;
    [SerializeField] private ParticleSystem _upgradePartSysteme3;
    private bool _isUpgrade1;
    private bool _isUpgrade2;
    private bool _isUpgrade3;

    [Header("Kill enemy")]
    public int standardEnemyKilled;
    public int speedEnemyKilled;
    public int bigEnemyKilled;
    public int littleEnemyKilled;

    [Header("Ulti")]
    [SerializeField] private Ulti _ulti;
    public float ultCharge = 0;
    public float maxUltCharge = 3;
    public float OldUltCharge = 0;
    public bool isUltCharged = false;
    

    [Header("GameOver")]
    [SerializeField] private GameObject _gameOverUI;
    public bool isGameFinished = false;
    [SerializeField] ParticleSystem _gameOverPartSysteme;
    private bool _isPartGOPlayed = false;

    public int playerLevelUpgrade;
    [SerializeField, HideInInspector] private GameObject _player;
    [SerializeField, HideInInspector] GameObject _enemySpawner;

    [Header("Combo")]
    [SerializeField] ParticleSystem _partCombo;
    [SerializeField] ParticleSystem _partBigCombo;
    [SerializeField] ParticleSystem _partCombo2;
    [SerializeField] ParticleSystem _partBigCombo2;
    [SerializeField] Animator _animCombo;
    public int combo;
    private bool _isPlayingPart;
    private bool _isPlayingBigPart;

    public bool isCurrentItem;

    public bool isFirstUlti = true;

    public bool isPhase2 = false;

    public bool isGamePlaying = true;

    [Header("SecretEnd")]
    public bool isSecretEnd = false;
    public bool isSecretGOScreen = false;
    [SerializeField] ParticleSystem _debrisSecretEnd;
    [SerializeField] GameObject _animSecretEnd;
    [SerializeField] GameObject _playerGfx;
    [SerializeField] GameObject _playerCanons;
    [SerializeField] GameObject _debrisSecretEndGO;
    [SerializeField] ParticleSystem _secretEndParticules;



    private void Awake()
    {
        //  _playerHealth = GetComponent<PlayerHealth>();
        _playerController = _player.GetComponent<PlayerController>();
        _playerHealth = _player.GetComponent<PlayerHealth>();
        isGamePlaying = true;
       // _animCombo = _animComboGO.GetComponent<Animator>();

    }
    void Start()
    {
        _canon2.SetActive(false);
        _canon3.SetActive(false);
        _canon4.SetActive(false);
        isUltCharged = false;

    }

    void Update()
    {
        isFirstUlti = _ulti.isFirstTime;

        if (_timer.seconds > 45.8) { isPhase2 = true;}

        if (!_playerHealth.isAlive )
        {
            GameOver();
        }
        _playerScoreUI.text = playerScore.ToString();

        #region Combo

        if (combo >= 40 && _playerHealth.isAlive && !_isPlayingPart)
        {
            _partCombo.Play();
            _partCombo2.Play();
            _isPlayingPart = true;
            _animCombo.enabled = true;
        }
        else if (combo < 40 && _playerHealth.isAlive && _isPlayingPart)
        {
            _partCombo.Stop();
            _partCombo2.Stop();
            _animCombo.enabled = false;
            _isPlayingPart = false;
        }

        if (combo >= 60 && _playerHealth.isAlive && !_isPlayingBigPart)
        {
            _partBigCombo.Play();
            _partBigCombo2.Play();
            _isPlayingBigPart = true;
        }
        else if(combo < 60 && _playerHealth.isAlive && _isPlayingBigPart)
        {
            _partBigCombo.Stop();
            _partBigCombo2.Stop();
            _isPlayingBigPart = false;
        }
        #endregion

        #region LevelWeapon
        if (playerLevelUpgrade >= 30)
        {
            _canon2.SetActive(true);
            _canon3.SetActive(true);
            _uiIcons._isLightOnIcon2 = true;
            if (!_isUpgrade1)
            {
                _upgradePartSysteme1.Play();
                _isUpgrade1 = true;
            }

        }
        else
        {
            _canon2.SetActive(false);
            _canon3.SetActive(false);
            _uiIcons._isLightOnIcon2 = false;
            _isUpgrade1 = false;


        }

        if (playerLevelUpgrade >= 90)
        {
            _canon4.SetActive(true);
            _uiIcons._isLightOnIcon3 = true;
            if (!_isUpgrade2)
            {
                _upgradePartSysteme2.Play();
                _isUpgrade2 = true;
            }
        }
        else
        {
            _canon4.SetActive(false);
            _uiIcons._isLightOnIcon3 = false;
            _isUpgrade2 = false;


        }
        if (playerLevelUpgrade >= 110)
        {
            _uiIcons._isLightOnIcon4 = true;
            if (!_isUpgrade3)
            {
                _upgradePartSysteme3.Play();
                _isUpgrade3 = true;
            }

        }
        else
        {
            _uiIcons._isLightOnIcon4 = false;
            _isUpgrade3 = false;

        }
        if (playerLevelUpgrade < 0) { playerLevelUpgrade = 0; }
        if (playerLevelUpgrade > 110) { playerLevelUpgrade = 110; }
        #endregion

        #region Ulti
        if (ultCharge > maxUltCharge) { ultCharge = maxUltCharge; }

        if (ultCharge == maxUltCharge) { isUltCharged = true; }
        else { isUltCharged = false; }
        if (ultCharge > OldUltCharge)
        {
            _ulti.UpdateUltBar();
            OldUltCharge = ultCharge;
        }
        #endregion

        if (isSecretEnd)
        {
            Invoke("SecretEnd", 2);
            

        }
    }

    private void GameOver()
    {
        isGamePlaying = false;
        if (!_isPartGOPlayed && !isSecretGOScreen)
        {
            _gameOverPartSysteme.Play();
            _isPartGOPlayed = true;
        }
        _playerController.gameObject.SetActive(false);
        _enemySpawner.SetActive(false);
        _itemSpawners.SetActive(false);
        isGameFinished = true;
        _gameOverUI.SetActive(true);
    }

    public void TakeItem()
    {
        
        isCurrentItem = true;
    }

   

    #region Secret

    IEnumerator PlayPartSecret()
    {
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(7.5f);
        _cameraController.shakeshake = false;

        _secretEndParticules.Play();
        _animSecretEnd.SetActive(false);

        yield return new WaitForSeconds(0.2f);
        _enemySpawner.SetActive(false);


        yield return new WaitForSeconds(2f);
        EndAfterSecretEnd();


    }
    public void SecretEnd()
    {

        _player.GetComponent<PlayerController>().enabled = false;
        _player.GetComponent<PlayerHealth>().enabled = false;
        _player.transform.position = new Vector3(0, 0, 0);
        _playerGfx.SetActive(false);
        _playerCanons.SetActive(false);
        _animSecretEnd.SetActive(true);
        StartCoroutine(PlayPartSecret());
        isGamePlaying = false;
        _cameraController.shakeshake = true;
        _debrisSecretEndGO.SetActive(true);

    }
    public void EndAfterSecretEnd() 
    {
        _secretEndParticules.Stop();

        _playerHealth.isAlive = false;
        _player.SetActive(false);
        _itemSpawners.SetActive(false);
        isGameFinished = true;
        _gameOverUI.SetActive(true);
        isSecretEnd = false;
        isSecretGOScreen = true;

    }
    #endregion

}
