using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private RadiusItem _radiusItem;
    [SerializeField] ParticleSystem _spawnItem;
    [SerializeField] GameObject _gfx;
    [SerializeField] Collider _collider;
    [SerializeField] ParticleSystem _destroyItem;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _destroyItemSound;
    private void Start()
    {
     // FindObjectOfType<GameManager>().GetComponent<ItemManager>().isRadiusItem = true;
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _radiusItem = GetComponent<RadiusItem>();
      StartCoroutine(DestroyItem());
        _spawnItem.Play();
        _collider = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            _gameManager.TakeItem();
        }
    }
    
    IEnumerator DestroyItem()
    {
        yield return new WaitForSeconds(5f);
        if (!_gameManager.isPhase2)
        {
            _audioSource.PlayOneShot(_destroyItemSound, 1.5f);
        }
        else
        {
            _audioSource.PlayOneShot(_destroyItemSound, 3f);
        }
        _collider.enabled = false;
        _gfx.SetActive(false);
        _destroyItem.Play();
       
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

}
