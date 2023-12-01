using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _buttonClip;
    // Start is called before the first frame update
    void Start()
    {
            _audioSource.PlayOneShot(_buttonClip, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchGameFunc()
    {
        SceneManager.LoadScene("GameScene");

    }
}
