using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject _player;
    public GameObject _enemys;
    public GameObject _pauseMenuUI;

    [Header("Particules Start")]
    public ParticleSystem _resumeButtonPart1;
    public ParticleSystem _resumeButtonPart2;
    public ParticleSystem _resumeButtonPart3;
    public ParticleSystem _resumeButtonPart4;
    public ParticleSystem _resumeButtonPart5;
    public ParticleSystem _resumeButtonPart6;

    [Header("Particules Retry")]
    public ParticleSystem _retryButtonPart1;
    public ParticleSystem _retryButtonPart2;
    public ParticleSystem _retryButtonPart3;
    public ParticleSystem _retryButtonPart4;
    public ParticleSystem _retryButtonPart5;
    public ParticleSystem _retryButtonPart6;

    [Header("Particules Menu")]
    public ParticleSystem _menuButtonPart1;
    public ParticleSystem _menuButtonPart2;
    public ParticleSystem _menuButtonPart3;
    public ParticleSystem _menuButtonPart4;
    public ParticleSystem _menuButtonPart5;
    public ParticleSystem _menuButtonPart6;

    [Header("Particules Quit")]
    public ParticleSystem _quitButtonPart1;
    public ParticleSystem _quitButtonPart2;
    public ParticleSystem _quitButtonPart3;
    public ParticleSystem _quitButtonPart4;
    public ParticleSystem _quitButtonPart5;
    public ParticleSystem _quitButtonPart6;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused) { Resume(); } else { Paused(); }
        }
    }

    public void Resume()
    {
        gameIsPaused = false;
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        _player.SetActive(true);
        _enemys.SetActive(true);

    }
    public void Paused()
    {
        gameIsPaused = true;
        StartAllPart();
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        _enemys.SetActive(false);
        _player.SetActive(false);

    }

    public void StartAllPart()
    {
        _resumeButtonPart1.Play();
        _resumeButtonPart2.Play();
        _resumeButtonPart3.Play();
        _resumeButtonPart4.Play();
        _resumeButtonPart5.Play();
        _resumeButtonPart6.Play();

        _retryButtonPart1.Play();
        _retryButtonPart2.Play();
        _retryButtonPart3.Play();
        _retryButtonPart4.Play();
        _retryButtonPart5.Play();
        _retryButtonPart6.Play();

        _menuButtonPart1.Play();
        _menuButtonPart2.Play();
        _menuButtonPart3.Play();
        _menuButtonPart4.Play();
        _menuButtonPart5.Play();
        _menuButtonPart6.Play();

        _quitButtonPart1.Play();
        _quitButtonPart2.Play();
        _quitButtonPart3.Play();
        _quitButtonPart4.Play();
        _quitButtonPart5.Play();
        _quitButtonPart6.Play();

    }


}
