using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool isRadiusItem;
    public bool isMegaBallsItem;
    public bool isDobleCanonItem;
    [SerializeField] Collider[] colliders;
    [SerializeField] Transform _player;
    float radiusGarlic = 4;
    [SerializeField] GameManager _gameManager;

    [SerializeField] GameObject canonSup1;
    [SerializeField] GameObject canonSup2;

    [SerializeField] ParticleSystem _shieldParticules;

    private void Update()
    {
        if (isRadiusItem)
        {
            ItemGarlic();
        }

        if (isMegaBallsItem)
        {
            StartCoroutine(EndItem());
        }

        if (isDobleCanonItem)
        {
            DoubleCanon();
        }
        else
        {
            canonSup1.SetActive(false);
            canonSup2.SetActive(false);
        }
        
    }
    public void ItemGarlic()
    {
        StartCoroutine(EndItem());
        colliders = Physics.OverlapSphere(_player.transform.position, radiusGarlic);
        _shieldParticules.Play();
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Destroy(collider.gameObject);
            }
        }
        StopCoroutine(EndItem());
    }

    public void DoubleCanon()
    {
        canonSup1.SetActive(true);
        canonSup2.SetActive(true);
        StartCoroutine(EndItem());

    }

    IEnumerator EndItem()
    {
        yield return new WaitForSeconds(5f);
        isRadiusItem = false;
        isMegaBallsItem = false;
        isDobleCanonItem = false;
        _gameManager.isCurrentItem = false;
        _shieldParticules.Play();
        _shieldParticules.Stop();
    }
}
