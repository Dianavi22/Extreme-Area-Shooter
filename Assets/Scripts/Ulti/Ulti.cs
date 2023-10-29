using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ulti : MonoBehaviour
{
    public static Ulti ulti;
    [SerializeField] private GameManager _gameManager;

    [Header("Laser")]
    [SerializeField] private Scale _scale;

    [Header("Garlic")]
    public float radiusGarlic;
    [SerializeField] GameObject _player;

    [Header("UI")]
    [SerializeField] private Slider slider;
    [SerializeField] private Material _sliderEmptyMaterial;
    [SerializeField] private Image _currentSliderMaterial;
    [SerializeField] private Material _sliderCompleteMaterial;

    [SerializeField] Collider[] colliders;

    public ParticleSystem flashLaser;
    public ParticleSystem sparksLaser;

    void Start()
    {
        slider.value = 0;
        radiusGarlic = 0;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _gameManager.isUltCharged)
        {
            Garlic();
            flashLaser.Play();
            sparksLaser.Play();
            _scale.LaunchUlti();
            _gameManager.ultCharge = 0;
            UpdateUltBar();
            _gameManager.isUltCharged = false;
            _gameManager.OldUltCharge = 0;
        }

        if(slider.value == 1)
        {
            _currentSliderMaterial.material = _sliderCompleteMaterial;
        }
        else{
            _currentSliderMaterial.material = _sliderEmptyMaterial;

        }



    }

    public void UpdateUltBar()
    {
        slider.value = _gameManager.ultCharge / _gameManager.maxUltCharge;
    }

    public void Garlic()
    {
        radiusGarlic = 7;
        colliders = Physics.OverlapSphere(_player.transform.position, radiusGarlic);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
               // print("ENEMY IN RADIUS");
                Destroy(collider.gameObject);

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_player.transform.position, radiusGarlic);
    }


}
