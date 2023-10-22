using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Spawner spawner;

    public void SpawnEnemy(GameObject objectToSpawn)
    {

        Instantiate(objectToSpawn, transform);
    }

  
}