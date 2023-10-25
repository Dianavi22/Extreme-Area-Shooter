using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] private UIIncons _uiIcons;
    [SerializeField]
    private GameObject _gameOverUI;
    [SerializeField]
    private PlayerHealth _playerHealth;
    [SerializeField] private GameObject _player;

    private PlayerController _playerController;
    public int playerScore;
    [SerializeField] TMP_Text _playerScoreUI;

    [SerializeField] private GameObject _canon2;
    [SerializeField] private GameObject _canon3;
    [SerializeField] private GameObject _canon4;
    [SerializeField] private GameObject _canon5;
    [SerializeField] private GameObject _canon6;

    [SerializeField] BulletSpawn _bulletSpawn;

    [SerializeField] GameObject _enemySpawner;

    public int playerLevelUpgrade;
    private void Awake()
    {
      //  _playerHealth = GetComponent<PlayerHealth>();
        _playerController = _player.GetComponent<PlayerController>();
        _playerHealth = _player.GetComponent<PlayerHealth>();

        
        
    }
    void Start()
    {
        _canon2.SetActive(false); 
        _canon3.SetActive(false);
        _canon4.SetActive(false);
        _canon5.SetActive(false);
        _canon6.SetActive(false);

    }

    void Update()
    {
        if (!_playerHealth.isAlive)
        {
            GameOver();
        }
        _playerScoreUI.text = playerScore.ToString();

        if(playerLevelUpgrade >= 30)
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
        //if (playerLevelUpgrade >= 90)
        //{
        //    _canon5.SetActive(true);
        //    _canon6.SetActive(true);
        //}
        //else
        //{
        //    _canon5.SetActive(false);
        //    _canon6.SetActive(false);
        //}


        if (playerLevelUpgrade < 0) { playerLevelUpgrade = 0; }
        if(playerLevelUpgrade > 110) { playerLevelUpgrade = 110; }

    }

    private void GameOver()
    {
        _playerController.gameObject.SetActive(false);
        _enemySpawner.SetActive(false);
        _gameOverUI.SetActive(true);
    }
}
