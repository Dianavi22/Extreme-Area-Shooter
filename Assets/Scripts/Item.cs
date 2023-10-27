using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void Start()
    {
      StartCoroutine(DestroyItem());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyItem()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
