using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _enemys;
    [SerializeField] GameObject _pauseMenuUI;
    [SerializeField] AudioSource _music;
    [SerializeField] AudioSource _musicPause;
    [SerializeField] Scale _scale;

    [Header("Particules Start")]
    [SerializeField] ParticleSystem _resumeButtonPart1;
    [SerializeField] ParticleSystem _resumeButtonPart2;
    [SerializeField] ParticleSystem _resumeButtonPart3;
    [SerializeField] ParticleSystem _resumeButtonPart4;
    [SerializeField] ParticleSystem _resumeButtonPart5;
    [SerializeField] ParticleSystem _resumeButtonPart6;

    [Header("Particules Retry")]
    [SerializeField] ParticleSystem _retryButtonPart1;
    [SerializeField] ParticleSystem _retryButtonPart2;
    [SerializeField] ParticleSystem _retryButtonPart3;
    [SerializeField] ParticleSystem _retryButtonPart4;
    [SerializeField] ParticleSystem _retryButtonPart5;
    [SerializeField] ParticleSystem _retryButtonPart6;

    [Header("Particules Menu")]
    [SerializeField] ParticleSystem _menuButtonPart1;
    [SerializeField] ParticleSystem _menuButtonPart2;
    [SerializeField] ParticleSystem _menuButtonPart3;
    [SerializeField] ParticleSystem _menuButtonPart4;
    [SerializeField] ParticleSystem _menuButtonPart5;
    [SerializeField] ParticleSystem _menuButtonPart6;

    [Header("Particules Quit")]
    [SerializeField] ParticleSystem _quitButtonPart1;
    [SerializeField] ParticleSystem _quitButtonPart2;
    [SerializeField] ParticleSystem _quitButtonPart3;
    [SerializeField] ParticleSystem _quitButtonPart4;
    [SerializeField] ParticleSystem _quitButtonPart5;
    [SerializeField] ParticleSystem _quitButtonPart6;

    
    void Start() 
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_scale.isCurrentUlti)
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
        _musicPause.Stop();
        _music.Play();
    }
    public void Paused()
    {
        gameIsPaused = true;
        StartAllPart();
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        _enemys.SetActive(false);
        _player.SetActive(false);

        _music.Pause();
        _musicPause.Play();

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

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        gameIsPaused = false;


    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1;
        gameIsPaused = false;

    }

    public void Quit()
    {
       Application.Quit();
    }

}
