using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCommands : MonoBehaviour
{

    [SerializeField] Material _checked;
    [SerializeField] Material _unchecked;
    [SerializeField] Image _caseChecked;
     [SerializeField] int _isChecked;
    void Start()
    {
        _isChecked = PlayerPrefs.GetInt("CommandChecked");
      
    }

    void Update()
    {
        if (_isChecked == 0)
        {
            _caseChecked.material = _checked;
        }
        else
        {
            _caseChecked.material = _unchecked;
        }
    }

    public void Checked()
    {
        if(_isChecked == 1)
        {
            _caseChecked.material = _checked;
            _isChecked = 0;
            PlayerPrefs.SetInt("CommandChecked", _isChecked);

        }
        else
        {
            _caseChecked.material = _unchecked;
            _isChecked = 1;
            PlayerPrefs.SetInt("CommandChecked", _isChecked);


        }
    }
}
