using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{

    [SerializeField] bool isGameFinished;
    public float seconds;
    private bool isRunning = false;
    public TMP_Text scoreText;

    private PlayerHealth _playerHealth;
    public static Timer timer;

    private void Awake()
    {
        if (timer != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameManager dans la scène");
            return;
        }

        timer = this;
        _playerHealth = FindObjectOfType<Player>().GetComponent<PlayerHealth>();

    }
    void Start()
    {
        seconds = 0;
        StartTimer();
    }
    void Update()
    {
        if (isRunning && isGameFinished == false)
        {
            IncreaseTimer();
        }
    }

    void StartTimer()
    {
        isRunning = true;
    }

    void IncreaseTimer()
    {
        if (_playerHealth.isAlive)
        {
            seconds += Time.deltaTime;
            //decompte
            //seconds -= Time.deltaTime;
            scoreText.text = seconds.ToString();
            float minute = Mathf.FloorToInt(seconds / 60);
            float sec = Mathf.FloorToInt(seconds % 60);
            if (sec < 10)
            {
                scoreText.text = minute + " :0" + sec.ToString();
            }
            else
            {
                scoreText.text = minute + " : " + sec.ToString();
            }
        }
        else
        {
            return;
        }
    }


}
