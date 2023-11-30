using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassHoverButtonsMenu : MonoBehaviour
{
    public bool _isHover = false;
    public ParticleSystem _part1;
    public ParticleSystem _part2;
    public ParticleSystem _part3;
    public ParticleSystem _part4;


    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _buttonSound;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnMouseEnter()
    {
        _isHover = true;
       
        _part3.Play();
        _part4.Play();
        Invoke("HorizontalPartEnter", 0.3f);
        _audioSource.PlayOneShot(_buttonSound, 0.5f);

    }

    public void HorizontalPartEnter()
    {
        _part1.Play();
        _part2.Play();
    }
    public void HorizontalPartExit()
    {
        _part1.Stop();
        _part2.Stop();
    }

    private void OnMouseExit()
    {
        _isHover = false;
       
        _part3.Stop();
        _part4.Stop();
        Invoke("HorizontalPartExit", 0.3f);


    }
}
