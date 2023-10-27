using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Spawner spawner;

    public void SpawnEnemy(GameObject objectToSpawn)
    {
        if(objectToSpawn == null)
        {
            return;
        }
        else
        {
            Instantiate(objectToSpawn, transform);
        }
    }

    public void SpawnItem(GameObject objectToSpawn)
    {
        if (objectToSpawn == null)
        {
            return;
        }
        else
        {
            Instantiate(objectToSpawn, transform);
        }
    }

}

  
