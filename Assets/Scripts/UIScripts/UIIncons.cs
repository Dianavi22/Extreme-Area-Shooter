using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIIncons : MonoBehaviour
{
    public static UIIncons _uiIncons;

    [Header("Icon1")]
    [SerializeField] Image _image1_icon1;
    [SerializeField] Image _image2_icon1;
    [SerializeField] Image _image3_icon1;
    [SerializeField] Image _image4_icon1;
    [SerializeField] Image _image5_icon1;
    [SerializeField] Image _image6_icon1;
    [SerializeField] Image _image7_icon1;

    [Header("Icon2")]
    [SerializeField] Image _image1_icon2;
    [SerializeField] Image _image2_icon2;
    [SerializeField] Image _image3_icon2;
    [SerializeField] Image _image4_icon2;
    [SerializeField] Image _image5_icon2;
    [SerializeField] Image _image6_icon2;
    [SerializeField] Image _image7_icon2;
    [SerializeField] Image _image8_icon2;
    [SerializeField] Image _image9_icon2;
    [SerializeField] Image _image10_icon2;

    [Header("Icon3")]
    [SerializeField] Image _image1_icon3;
    [SerializeField] Image _image2_icon3;
    [SerializeField] Image _image3_icon3;
    [SerializeField] Image _image4_icon3;
    [SerializeField] Image _image5_icon3;
    [SerializeField] Image _image6_icon3;
    [SerializeField] Image _image7_icon3;
    [SerializeField] Image _image8_icon3;
    [SerializeField] Image _image9_icon3;

    [Header("Icon4")]
    [SerializeField] Image _image1_icon4;
    [SerializeField] Image _image2_icon4;
    [SerializeField] Image _image3_icon4;
    [SerializeField] Image _image4_icon4;
    [SerializeField] TMP_Text _text1_icon4;

    [Header("Bools Turn On")]
    public bool _isLightOnIcon1;
    public bool _isLightOnIcon2;
    public bool _isLightOnIcon3;
    public bool _isLightOnIcon4;

    [SerializeField] Material _glowLight;

    private void Start()
    {
        _isLightOnIcon1 = true;
    }
    private void Update()
    {
        LightOnIcon1();
        LightOnIcon2();
        LightOnIcon3();
        LightOnIcon4();
    }

    public void LightOnIcon1()
    {
        if (_isLightOnIcon1)
        {
            _image1_icon1.material = _glowLight;
            _image2_icon1.material = _glowLight;
            _image3_icon1.material = _glowLight;
            _image4_icon1.material = _glowLight;
            _image5_icon1.material = _glowLight;
            _image6_icon1.material = _glowLight;
            _image7_icon1.material = _glowLight;
        }
        else
        {
            _image1_icon1.material = null;
            _image2_icon1.material = null;
            _image3_icon1.material = null;
            _image4_icon1.material = null;
            _image5_icon1.material = null;
            _image6_icon1.material = null;
            _image7_icon1.material = null;
        }
    }
    public void LightOnIcon2()
    {
        if (_isLightOnIcon2)
        {

            _image1_icon2.material = _glowLight;
            _image2_icon2.material = _glowLight;
            _image3_icon2.material = _glowLight;
            _image4_icon2.material = _glowLight;
            _image5_icon2.material = _glowLight;
            _image6_icon2.material = _glowLight;
            _image7_icon2.material = _glowLight;
            _image8_icon2.material = _glowLight;
            _image9_icon2.material = _glowLight;
            _image10_icon2.material = _glowLight;
        }
        else
        {
            _image1_icon2.material = null;
            _image2_icon2.material = null;
            _image3_icon2.material = null;
            _image4_icon2.material = null;
            _image5_icon2.material = null;
            _image6_icon2.material = null;
            _image7_icon2.material = null;
            _image8_icon2.material = null;
            _image9_icon2.material = null;
            _image10_icon2.material = null;
        }
    }
    public void LightOnIcon3()
    {
        if (_isLightOnIcon3)
        {

            _image1_icon3.material = _glowLight;
            _image2_icon3.material = _glowLight;
            _image3_icon3.material = _glowLight;
            _image4_icon3.material = _glowLight;
            _image5_icon3.material = _glowLight;
            _image6_icon3.material = _glowLight;
            _image7_icon3.material = _glowLight;
            _image8_icon3.material = _glowLight;
            _image9_icon3.material = _glowLight;
        }
        else
        {
            _image1_icon3.material = null;
            _image2_icon3.material = null;
            _image3_icon3.material = null;
            _image4_icon3.material = null;
            _image5_icon3.material = null;
            _image6_icon3.material = null;
            _image7_icon3.material = null;
            _image8_icon3.material = null;
            _image9_icon3.material = null;
        }
    }
    public void LightOnIcon4()
    {
        if (_isLightOnIcon4)
        {
            _image1_icon4.material = _glowLight;
            _image2_icon4.material = _glowLight;
            _image3_icon4.material = _glowLight;
            _image4_icon4.material = _glowLight;
            _text1_icon4.material = _glowLight;
        }
        else
        {
            _image1_icon4.material = null;
            _image2_icon4.material = null;
            _image3_icon4.material = null;
            _image4_icon4.material = null;
            _text1_icon4.material = null;
        }
    }

}
