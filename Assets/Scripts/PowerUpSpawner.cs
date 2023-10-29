using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    private float _lastSpawnItem;
    private float m_ItemRate = 0.055f;

    public List<Spawner> itemsSpawner;
    public List<GameObject> items;

    [SerializeField] GameManager _gameManager;
    private void Update()
    {
        if ((Time.time - _lastSpawnItem) >= (1f / m_ItemRate) && !_gameManager.isCurrentItem)
        {
            _lastSpawnItem = Time.time;
            ItemSpawn();
        }
    }
    public void ItemSpawn() { itemsSpawner[Random.Range(0, itemsSpawner.Count)].SpawnItem(items[Random.Range(0, items.Count)]);}
}
