using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    public AudioClip[] songs;
    public float volume;
    [SerializeField] GameManager _gameManager;

    private void Start()
    {
        _audioSource.clip = songs[0];
    }
    private void Update()
    {
        _audioSource.volume = volume;
        if (!_gameManager.isGamePlaying)
        {
            _audioSource.volume = 0.35f;
        }
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = songs[1];
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }
}
