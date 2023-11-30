using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject _cubes;
    [SerializeField] private GameObject _particules;
    private AudioMenuManager _dontDestroyOnLoad;


    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _buttonClip;
    private void Awake()
    {

        _dontDestroyOnLoad = FindAnyObjectByType<AudioMenuManager>();
    }
    void Start()
    {
        _audioSource.PlayOneShot(_buttonClip, 0.5f);

        Invoke("SetActiveCubes", 0.65f);
    }

    void Update()
    {

    }

    private void SetActiveCubes()
    {
        _particules.SetActive(false);
        _cubes.SetActive(true);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Destroy(_dontDestroyOnLoad.gameObject);
    }
}
