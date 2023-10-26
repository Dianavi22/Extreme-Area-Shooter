using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ulti : MonoBehaviour
{
    public static Ulti ulti;
    [SerializeField] private GameManager _gameManager;
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
}
