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
    [SerializeField] private bool isCurrentEventReady = false;
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
            print("HERE");
        }
    }

    public void EventStandardEnemy()
    {
        print("Standard");
        _enemySpawner.current_Rate = 4f;
        _enemySpawner.current_RateExploseEnemy = 0f;
        _enemySpawner.current_RateBigEnemy = 0f;
    }
    public void EventBigEnemy()
    {
        print("BigEnemy");

        _enemySpawner.current_RateBigEnemy = 1.3f;
        _enemySpawner.current_RateExploseEnemy = 0f;
        _enemySpawner.current_Rate = 0f;
    }

    public void EventSpeedEnemy()
    {
        print("Speed");

        _enemySpawner.current_RateExploseEnemy = 5f;
        _enemySpawner.current_RateBigEnemy = 0f;
        _enemySpawner.current_Rate = 0f;
    }

    IEnumerator LaunchRandomEvent()
    {
        print("IN COROUTINE");

        isCurrentEvent = true;
        isCurrentEventReady = false;
        int _currentEvent = Random.Range(0, 5);
        if(_currentEvent == 0) { EventBigEnemy(); }
        else if(_currentEvent == 1) { EventStandardEnemy(); }
        else if(_currentEvent == 2) { EventBigEnemy(); }
        else if(_currentEvent == 3) { EventSpeedEnemy(); }
        else if(_currentEvent == 4) { EventStandardEnemy(); }
        else { EventSpeedEnemy(); }

        yield return new WaitForSeconds(10f);
        isCurrentEvent = false;
        _enemySpawner.ResetTimeSpawn();
        _enemySpawner.ResetSpawnEnemy();

        yield return new WaitForSeconds(25f);
        isCurrentEventReady = true;
    }


}
