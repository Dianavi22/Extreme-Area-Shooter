using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager eventManager;
    [SerializeField] EnemySpawner _enemySpawner;
    [SerializeField] Timer _timer;
    private bool isEventStandardEnemy;
    public bool isCurrentEvent = false;
    private bool isCurrentEventReady = false;
    private bool isEventStarting = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(_timer.seconds >= 70 && isEventStarting) {
            isCurrentEventReady=true;
            isEventStarting = false;
        }
        if(_timer.seconds > 70 && isCurrentEventReady && !isCurrentEvent)
        {
            StartCoroutine(LaunchRandomEvent());
        }
    }

    public void EventStandardEnemy()
    {
        _enemySpawner.m_Rate = 4f;
        _enemySpawner.m_RateBigEnemy = 0f;
        _enemySpawner.m_RateExploseEnemy = 0f;
    }
    public void EventBigEnemy()
    {
        _enemySpawner.m_RateBigEnemy = 1.3f;
        _enemySpawner.m_RateExploseEnemy = 0f;
        _enemySpawner.m_Rate = 0f;
    }

    public void EventSpeedEnemy()
    {
        _enemySpawner.m_RateExploseEnemy = 5f;
        _enemySpawner.m_RateBigEnemy = 0f;
        _enemySpawner.m_Rate = 0f;
    }

    IEnumerator LaunchRandomEvent()
    {
        isCurrentEvent = true;
        isCurrentEventReady = false;
        int _currentEvent = Random.Range(0, 5);
        if(_currentEvent == 0) { EventBigEnemy(); }
        else if(_currentEvent == 1) { EventStandardEnemy(); }
        else if(_currentEvent == 2) { EventBigEnemy(); }
        else if(_currentEvent == 3) { EventSpeedEnemy(); }
        else if(_currentEvent == 4) { EventStandardEnemy(); }
        else { EventSpeedEnemy(); }

        yield return new WaitForSeconds(15f);
        isCurrentEvent = false;

        yield return new WaitForSeconds(25f);
        isCurrentEventReady = true;
    }
}
