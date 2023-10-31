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

    public static GameManager gameManager;
    private PlayerController _playerController;
    [SerializeField] GameObject _itemSpawners;  

    [Header("Scoring")]
    [SerializeField] TMP_Text _playerScoreUI;
    public int playerScore;

    [Header("Weapon")]
    [SerializeField, HideInInspector] private GameObject _canon2;
    [SerializeField, HideInInspector] private GameObject _canon3;
    [SerializeField, HideInInspector] private GameObject _canon4;

    [Header("Kill enemy")]
    public int standardEnemyKilled;
    public int speedEnemyKilled;
    public int bigEnemyKilled;
    public int littleEnemyKilled;

    [Header("Ulti")]
    [SerializeField] private Ulti _ulit;
    public float ultCharge = 0;
    public float maxUltCharge = 3;
    public float OldUltCharge = 0;
    public bool isUltCharged = false;

    [Header("GameOver")]
    [SerializeField] private GameObject _gameOverUI;
    public bool isGameFinished = false;

    public int playerLevelUpgrade;
    [SerializeField, HideInInspector] private GameObject _player;
    [SerializeField, HideInInspector] GameObject _enemySpawner;

    public bool isCurrentItem;

    [SerializeField] ParticleSystem _partCombo;
    [SerializeField] ParticleSystem _partBigCombo;
    // [SerializeField] GameObject _animComboGO;
    [SerializeField] Animator _animCombo;

    public int combo;
    private void Awake()
    {
        //  _playerHealth = GetComponent<PlayerHealth>();
        _playerController = _player.GetComponent<PlayerController>();
        _playerHealth = _player.GetComponent<PlayerHealth>();

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
        if (!_playerHealth.isAlive)
        {
            GameOver();
        }
        _playerScoreUI.text = playerScore.ToString();

        if(combo >= 40 && _playerHealth.isAlive)
        {
            _partCombo.Play();
            _animCombo.enabled = true;
        }
        else
        {
            _partCombo.Stop();
            _animCombo.enabled = false;
        }

        if (combo >= 60 && _playerHealth.isAlive)
        {
            _partBigCombo.Play();
        }
        else
        {
            _partBigCombo.Stop();

        }

        #region LevelWeapon
        if (playerLevelUpgrade >= 30)
        {
            _canon2.SetActive(true);
            _canon3.SetActive(true);
            _uiIcons._isLightOnIcon2 = true;
        }
        else
        {
            _canon2.SetActive(false);
            _canon3.SetActive(false);
            _uiIcons._isLightOnIcon2 = false;

        }

        if (playerLevelUpgrade >= 90)
        {
            _canon4.SetActive(true);
            _uiIcons._isLightOnIcon3 = true;

        }
        else
        {
            _canon4.SetActive(false);
            _uiIcons._isLightOnIcon3 = false;

        }
        if (playerLevelUpgrade >= 110)
        {
            _uiIcons._isLightOnIcon4 = true;
        }
        else
        {
            _uiIcons._isLightOnIcon4 = false;
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
            _ulit.UpdateUltBar();
            OldUltCharge = ultCharge;
        }
        #endregion


    }

    private void GameOver()
    {
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

}
