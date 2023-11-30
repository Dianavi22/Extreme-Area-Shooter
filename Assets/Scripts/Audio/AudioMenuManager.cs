using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenuManager : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    public AudioClip[] songs;
    public float volume;

    private void Awake()
    {
   
            DontDestroyOnLoad(gameObject);
        
    }
    private void Start()
    {
        _audioSource.clip = songs[0];
    }
    private void Update()
    {
        _audioSource.volume = volume;
       
        if (!_audioSource.isPlaying && !PauseMenu.gameIsPaused)
        {
            _audioSource.clip = songs[1];
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }
}
