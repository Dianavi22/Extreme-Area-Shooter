using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_StandardEnemyPr;
    private float _lastSpawn;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //public void StandardEnemySpawn()
    //{
    //    GameObject enemy = Instantiate(m_Prefab);
    //    enemy.transform.position = transform.position;
    //    enemy.transform.localPosition = new Vector3(Random.Range(transform.localPosition.x - m_Width * 0.5f, transform.localPosition.x + m_Width * 0.5f), 0, 0);
    //}
}
