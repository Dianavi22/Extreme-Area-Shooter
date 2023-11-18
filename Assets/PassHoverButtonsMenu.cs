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
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnMouseEnter()
    {
        _isHover = true;
        _part1.Play();
        _part2.Play();
        _part3.Play();
        _part4.Play();
    }

    private void OnMouseExit()
    {
        _isHover = false;
        _part1.Stop();
        _part2.Stop();
        _part3.Stop();
        _part4.Stop();

    }
}
