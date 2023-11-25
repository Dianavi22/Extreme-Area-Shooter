using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public float bestTime;
    public int bestKills;
    public int bestScore;
    [SerializeField] TMP_Text bestTimeText;
    [SerializeField] TMP_Text bestKillsText;
    [SerializeField] TMP_Text bestScoreText;
    [SerializeField] GameOver _gameOver;
    [SerializeField] Timer _timer;
    [SerializeField] GameManager _gameManager;
    public static SaveData saveData;

    private void Awake()
    {
        bestTime = PlayerPrefs.GetFloat("Time");
        bestKills = PlayerPrefs.GetInt("Kills");
        bestScore = PlayerPrefs.GetInt("Score");

        ConvertTime();
        bestKillsText.text = bestKills.ToString();
        bestScoreText.text = bestScore.ToString();
    }
    private void Start()
    {
        //PlayerPrefs.SetFloat("Time", 0);
        //PlayerPrefs.SetInt("Score", 0);
        //PlayerPrefs.SetInt("Kills", 0);
    }
    void Update()
    {
        //ConvertTime();
        //bestKillsText.text = bestKills.ToString();
        //bestScoreText.text = bestScore.ToString();
    }

    public void VerifTimeRecord()
    {
        if (bestTime < _timer.seconds)
        {
            PlayerPrefs.SetFloat("Time", _timer.seconds);
            bestTime = _timer.seconds;
            ConvertTime();
        }
    }

    public void VerifKillsRecord()
    {
        if (bestKills < _gameOver.totalKills)
        {
            PlayerPrefs.SetInt("Kills", _gameOver.totalKills);
            bestKills = _gameOver.totalKills;
            bestKillsText.text = bestKills.ToString();
        }
    }
    public void VerifScoreRecord()
    {
        if (bestScore < _gameManager.playerScore)
        {
            PlayerPrefs.SetInt("Score", _gameManager.playerScore);
            bestScore = _gameManager.playerScore;
            bestScoreText.text = bestScore.ToString();

        }
    }

    void ConvertTime()
    {
        float minute = Mathf.FloorToInt(bestTime / 60);
        float sec = Mathf.FloorToInt(bestTime % 60);
        if (sec < 10)
        {
            bestTimeText.text = minute + " :0" + sec.ToString();
        }
        else
        {
            bestTimeText.text = minute + " : " + sec.ToString();
        }
    }

}



