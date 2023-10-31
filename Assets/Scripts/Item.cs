using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private RadiusItem _radiusItem;
    [SerializeField] ParticleSystem _spawnItem;
    private void Start()
    {
     // FindObjectOfType<GameManager>().GetComponent<ItemManager>().isRadiusItem = true;
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _radiusItem = GetComponent<RadiusItem>();
      StartCoroutine(DestroyItem());
        _spawnItem.Play();
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
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

}
