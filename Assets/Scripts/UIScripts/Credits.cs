using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject _cubes;
    [SerializeField] private GameObject _particules;

    void Start()
    {
        Invoke("SetActiveCubes", 0.65f);
    }

    void Update()
    {
        
    }

    private void SetActiveCubes()
    {
        //_cubes.SetActive(true);
        //_particules.SetActive(false);
        _cubes.SetActive(true);    
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MenuScene");

    }
}
