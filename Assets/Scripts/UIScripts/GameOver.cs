using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] SaveData _saveData;
    public static GameOver gameOver;
    [SerializeField] Timer timer;
    [SerializeField]  private TMP_Text _timeEnd;
    [SerializeField]  private TMP_Text _standardEnemyKillText;
    [SerializeField]  private TMP_Text _speedEnemyKillText;
    [SerializeField]  private TMP_Text _bigEnemyKillText;
    [SerializeField]  private TMP_Text _littleEnemyKillText;
    [SerializeField]  private TMP_Text _totalKillsText;
    [SerializeField]  private TMP_Text _playerScoreText;
    public int totalKills;
    void Start()
    {

    }

    void Update()
    {
        if (gameManager.isGameFinished)
        {
            _saveData.VerifTimeRecord();
            _saveData.VerifKillsRecord();
            _saveData.VerifScoreRecord();
        }
        _timeEnd.text = timer.scoreText.text;
        _standardEnemyKillText.text = gameManager.standardEnemyKilled.ToString();
        _speedEnemyKillText.text = gameManager.speedEnemyKilled.ToString();
        _bigEnemyKillText.text = gameManager.bigEnemyKilled.ToString();
        _littleEnemyKillText.text = gameManager.littleEnemyKilled.ToString();
        totalKills = gameManager.standardEnemyKilled + gameManager.speedEnemyKilled + gameManager.bigEnemyKilled + gameManager.littleEnemyKilled;
        _totalKillsText.text = totalKills.ToString();
        _playerScoreText.text = gameManager.playerScore.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
