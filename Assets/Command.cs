using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    [SerializeField] ParticleSystem _sparksHover1;
    [SerializeField] ParticleSystem _sparksHover2;
    [SerializeField] ParticleSystem _sparksHover3;
    [SerializeField] ParticleSystem _sparksHover4;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

 
    private void OnMouseEnter()
    {
        _sparksHover1.Play();
        _sparksHover2.Play();
        _sparksHover3.Play();
        _sparksHover4.Play();
    }
}
