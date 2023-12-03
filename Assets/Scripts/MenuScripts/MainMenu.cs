using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Transform _image1;
    [SerializeField] private Transform _image2;
    [SerializeField] private Transform _image3;
    [SerializeField] private Transform _image4;
    public bool isHover;

    public bool isFullScreen;
    private int _isCheckedCommmands;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _buttonClip;

    [SerializeField] private static bool _isSoundPlaying = true;
    // Start is called before the first frame update

    private void Awake()
    {
        

    }
    void Start()
    {

        if (_isSoundPlaying) 
        {
            return;
        }
        else
        {
            _audioSource.PlayOneShot(_buttonClip, 0.2f);

        }
        Transform _startImage1 = _image1;
        Transform _startImage2 = _image2;
        Transform _startImage3 = _image3;
        Transform _startImage4 = _image4;
        isFullScreen = true;
        Screen.fullScreen = isFullScreen;

        _isCheckedCommmands = PlayerPrefs.GetInt("CommandChecked");
    }

    // Update is called once per frame
    void Update()
    {
        if (isHover)
        {

            HoverButton();
            
        }

        
    }

    public void StartGame()
    {
        if (_isCheckedCommmands == 0)
        {
            _isSoundPlaying = false;
            SceneManager.LoadScene("CommandScene");
        }
        else {
            _isSoundPlaying = false;

            SceneManager.LoadScene("GameScene");

        }

    } 
    public void StartCommands()
    {
        _isSoundPlaying = false;

        SceneManager.LoadScene("CommandScene");

    }

    public void Credits()
    {


        _isSoundPlaying = false;

        SceneManager.LoadScene("CreditScene");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowCommand()
    {

    }

    public void HoverButton()
    {
        _image1.localScale = new Vector3(_image1.localScale.x, 0, _image1.localScale.z); ; 
        _image2.localScale = new Vector3(_image2.localScale.x, 0, _image2.localScale.z); ; 
        _image3.localScale = new Vector3(_image3.localScale.x, 0, _image3.localScale.z); ; 
        _image4.localScale = new Vector3(_image4.localScale.x, 0, _image4.localScale.z); ; 
    }
}
