using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject _cubes;
    [SerializeField] private GameObject _particules;
    private AudioMenuManager _dontDestroyOnLoad;


    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _buttonClip;
    [SerializeField] AudioClip _keyboard1;
    [SerializeField] AudioClip _keyboard2;
    [SerializeField] private TMP_Text _thanksText;
    [SerializeField] private TMP_Text _gameDesignText;
    [SerializeField] private TMP_Text _musicText;
    [SerializeField] private TMP_Text _musicMenuText;

    [SerializeField] private TMP_Text _gameDesignText2;
    [SerializeField] private TMP_Text _musicText2;
    [SerializeField] private TMP_Text _musicMenuText2;
    private void Awake()
    {

        _dontDestroyOnLoad = FindAnyObjectByType<AudioMenuManager>();
    }
    void Start()
    {
        _audioSource.PlayOneShot(_buttonClip, 0.2f);

        Invoke("SetActiveCubes", 0.65f);

        StartCoroutine(OrderSentences());

    }

    void Update()
    {

    }

 

    IEnumerator OrderSentences()
    {
        yield return new WaitForSeconds(1f);
        _audioSource.PlayOneShot(_keyboard1, 0.2f);
        StartCoroutine(TypeSentence("GAME DESIGNED BY", _gameDesignText));

        yield return new WaitForSeconds(0.3f);
        _audioSource.PlayOneShot(_keyboard2, 0.2f);

        StartCoroutine(TypeSentence("MUSIC GAME BY ", _musicText));
        yield return new WaitForSeconds(0.3f);
        _audioSource.PlayOneShot(_keyboard1, 0.2f);

        StartCoroutine(TypeSentence("MUSIC MENU BY", _musicMenuText));
        yield return new WaitForSeconds(0.3f);
        _audioSource.PlayOneShot(_keyboard2, 0.2f);

        StartCoroutine(TypeSentence("JADO", _gameDesignText2));
        yield return new WaitForSeconds(0.3f);
        _audioSource.PlayOneShot(_keyboard1, 0.2f);

        StartCoroutine(TypeSentence("KEVIN MACLEOD", _musicText2));
        yield return new WaitForSeconds(0.3f);
        _audioSource.PlayOneShot(_keyboard2, 0.2f);

        StartCoroutine(TypeSentence("CARPENTER BRUT (FURI)", _musicMenuText2));
        yield return new WaitForSeconds(0.3f);
        _audioSource.PlayOneShot(_keyboard1, 0.2f);

        StartCoroutine(TypeSentence("THANKS TO PLAY TESTERS", _thanksText));

    }

    private void SetActiveCubes()
    {
        _particules.SetActive(false);
        _cubes.SetActive(true);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MenuScene");
        try { Destroy(_dontDestroyOnLoad.gameObject); }
        catch { return;  }
    }

    IEnumerator TypeSentence(string sentence, TMP_Text place)
    {
        
        foreach (char letter in sentence.ToCharArray())
        {
            yield return new WaitForSeconds(0.005f);

            place.text += letter;
            yield return null;
        }
    }
}
