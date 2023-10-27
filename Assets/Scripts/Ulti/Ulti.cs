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
    private float _radiusGarlic = 0;
    [SerializeField] GameObject _player;

    [Header("UI")]
    [SerializeField] private Slider slider;
    [SerializeField] private Material _sliderEmptyMaterial;
    [SerializeField] private Image _currentSliderMaterial;
    [SerializeField] private Material _sliderCompleteMaterial;

    void Start()
    {
        slider.value = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _gameManager.isUltCharged)
        {
            Garlic();
            _scale.LaunchUlti();
            _gameManager.ultCharge = 0;
            UpdateUltBar();
            _gameManager.isUltCharged = false;
            _gameManager.OldUltCharge = 0;
        }

        if (!_gameManager.isUltCharged)
        {
            _radiusGarlic = 0;
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
        _radiusGarlic = 5;
        Collider[] colliders = Physics.OverlapSphere(_player.transform.position, _radiusGarlic);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
              Destroy(collider.gameObject);
               
            }
        }
    }

    
}
