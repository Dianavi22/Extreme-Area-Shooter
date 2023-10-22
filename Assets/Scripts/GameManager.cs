using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField]
    private GameObject _gameOverUI;
    [SerializeField]
    private PlayerHealth _playerHealth;
    [SerializeField] private GameObject _player;

    private PlayerController _playerController;
    public int playerScore;
    [SerializeField] TMP_Text _playerScoreUI;
    private void Awake()
    {
      //  _playerHealth = GetComponent<PlayerHealth>();
        _playerController = _player.GetComponent<PlayerController>();
        _playerHealth = _player.GetComponent<PlayerHealth>();
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (!_playerHealth.isAlive)
        {
            GameOver();
        }
        _playerScoreUI.text = playerScore.ToString();

    }

    private void GameOver()
    {
        _playerController.gameObject.SetActive(false);
        _gameOverUI.SetActive(true);
    }
}
