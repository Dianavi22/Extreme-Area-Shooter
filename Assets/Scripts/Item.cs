using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private RadiusItem _radiusItem;
    private void Start()
    {
     // FindObjectOfType<GameManager>().GetComponent<ItemManager>().isRadiusItem = true;
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _radiusItem = GetComponent<RadiusItem>();
      StartCoroutine(DestroyItem());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            // _radiusItem.gameObject.SetActive(true);
            _gameManager.TakeItem();
        }
    }

    IEnumerator DestroyItem()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    
}
