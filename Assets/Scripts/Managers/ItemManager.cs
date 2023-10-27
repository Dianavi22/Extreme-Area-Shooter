using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool isRadiusItem;
    [SerializeField] Collider[] colliders;
    [SerializeField] Transform _player;
    float radiusGarlic = 4;
    [SerializeField] GameManager _gameManager;

    private void Update()
    {
        if (isRadiusItem)
        {
            ItemGarlic();
        }
    }
    public void ItemGarlic()
    {
        StartCoroutine(EndItem());
        colliders = Physics.OverlapSphere(_player.transform.position, radiusGarlic);
        foreach (Collider collider in colliders)
        {

            if (collider.tag == "Enemy")
            {
                Destroy(collider.gameObject);
            }
        }
        StopCoroutine(EndItem());

    }

    IEnumerator EndItem()
    {
        yield return new WaitForSeconds(5f);
        isRadiusItem = false;
        _gameManager.isCurrentItem = false;
    }
}
